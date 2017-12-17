using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;


// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace GetBooksFromOpenBd
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int count = 1000;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async Task<string> ReadFile(string fileName)
        {
            // Assetsからのファイル取り出し
            var file = await StorageFile.GetFileFromApplicationUriAsync(new Uri($"ms-appx:///Assets/{fileName}"));
            // ファイルの読み込み
            string str = await FileIO.ReadTextAsync(file);
            return str;           
        }

        private async void Button_OnClick(object sender, RoutedEventArgs e)
        {
            Button.IsEnabled = false;
            ProgressRing.IsActive = true;
            var file = await ReadFile("isbn.txt");
            // ISBNをcount個ずつグループ化
            var isbnList = file.Split(',')
                .Select((p, i) => new { Content = p, Index = i })
                .GroupBy(ano => ano.Index / count, ano => ano.Content);

            foreach (var line in isbnList)
            {
                var json = await GetJsonFromOpenBd(line);
                var books = JsonConvert.DeserializeObject<List<Book>>(json);
                var booksWithPrice = books.Where(item => item.Onix.ProductSupply.SupplyDetail.Price != null && item.Summary.Cover != "").ToList();

                if (booksWithPrice.Any())
                {
                    var str = "";
                    foreach (var book in booksWithPrice)
                    {
                        str +=
                            $"\"{book.Summary.Isbn}\",\"{book.Summary.Title}\",\"{book.Summary.Publisher}\",\"{book.Summary.Author}\",\"{book.Summary.Pubdate}\",\"{book.Onix.ProductSupply.SupplyDetail.Price.First().PriceAmount}\",\"{book.Summary.Cover}\"\n";
                    }
                    Output.Text += $"{booksWithPrice.First().Summary.Isbn}-{booksWithPrice.Last().Summary.Isbn}\n";
                    var fileName = $"{booksWithPrice.First().Summary.Isbn}-{booksWithPrice.Last().Summary.Isbn}.csv";
                    await SaveFile(str, fileName);
                }
            }

            Output.Text += "完了";
            Button.IsEnabled = true;
            ProgressRing.IsActive = false;
        }

        private async Task<string> GetJsonFromOpenBd(IGrouping<int, string> line)
        {
            var isbn = line.Select(item => item);
            var isbnUrl = string.Join(",", isbn);
            var url = "https://api.openbd.jp/v1/get?isbn=" + isbnUrl;
            var json = await new HttpClient().GetStringAsync(url);
            return json;
        }

        private async Task SaveFile(string str, string fileName)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var file = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            var newFile = await storageFolder.GetFileAsync(fileName);
            await FileIO.WriteTextAsync(newFile, str);
        }
    }
}
