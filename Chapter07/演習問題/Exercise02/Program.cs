
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
    new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
    new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
    new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
    new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
    new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
    new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
    new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
};
            #region
            Console.WriteLine("7.2.1");
            Exercise1(books);
            Console.WriteLine("--------------------------------");

            Console.WriteLine("7.2.2");
            Exercise2(books);
            Console.WriteLine("--------------------------------");


            Console.WriteLine("7.2.3");
            Exercise3(books);
            Console.WriteLine("--------------------------------");


            Console.WriteLine("7.2.4");
            Exercise4(books);
            Console.WriteLine("--------------------------------");


            Console.WriteLine("7.2.5");
            Exercise5(books);
            Console.WriteLine("--------------------------------");


            Console.WriteLine("7.2.6");
            Exercise6(books);
            Console.WriteLine("--------------------------------");


            Console.WriteLine("7.2.7");
            Exercise7(books);
            #endregion

        }

        private static void Exercise1(List<Book> books) {
            var book = books.Where(s => s.Title.Contains("ワンダフル・C#ライフ"));
            foreach (var item in book) {
                Console.WriteLine("ワンダフル・C#ライフとある書籍のページと価格：" + item.Price + "/" + item.Pages);
            }
        }

        private static void Exercise2(List<Book> books) {
            Console.WriteLine("C#が含まれている書籍が何冊あるかカウントする：" + books.Count(s => s.Title.Contains("C#")));

        }

        private static void Exercise3(List<Book> books) {
            var value = books.Where(s => s.Title.Contains("C#")).Average(s => s.Pages);
            Console.WriteLine("C#が含まれている書籍の平均ページ数：" + value);
        }

        private static void Exercise4(List<Book> books) {
            var book = books.Where(s => 4000 <= s.Price).First();
            Console.WriteLine("４０００円以上の本で最初に見つかった本のタイトル：" + book.Title);
        }

        private static void Exercise5(List<Book> books) {
            Console.WriteLine("４０００円未満の本の中で最大ページ数：" + books.Where(s => s.Price < 4000).Max(s => s.Pages));
        }

        private static void Exercise6(List<Book> books) {
            var book = books.Where(s => 400 <= s.Pages).OrderByDescending(s => s.Price);
            foreach (var item in book) {
                Console.WriteLine("ページ数が４００ページ以上の書籍を降順でタイトル表示：" + item.Title + "/" + item.Price);
            }
        }

        private static void Exercise7(List<Book> books) {
            var book = books.Where(s => s.Title.Contains("C#") && s.Pages <= 500);
            foreach (var item in book) {
                Console.WriteLine("タイトルにC#が含まれていて、ページ数が５００ページ以下の書籍のタイトル表示：" + item.Title);
            }
        }
    }
}
