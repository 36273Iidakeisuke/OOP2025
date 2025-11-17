namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //この笑顔１００円
            var books = Books.GetBooks();

            //本の平均金額を表示
            Console.WriteLine(books.Average(s => s.Price));

            Console.WriteLine("-------------------------");

            //本のページ合計を表示
            Console.WriteLine(books.Sum(s => s.Pages));

            Console.WriteLine("-------------------------");

            //金額の安い書籍名と金額を表示
            var book = books.Where(s => s.Price == books.Min(b => b.Price)).First();
            Console.WriteLine("安い書籍名：" + book.Title + "  安い金額：" + book.Price);

            Console.WriteLine("-------------------------");

            //ページが多い書籍名とページ数を表示
            var book1 = books.Where(s => s.Pages == books.Max(b => b.Pages)).First();
            Console.WriteLine("多い書籍名：" + book1.Title + "  多いページ数：" + book1.Pages);

            Console.WriteLine("-------------------------");

            //タイトルに「物語」が含まれている書籍名をすべて表示
            var found = books.Where(s => s.Title.Contains("物語"));
            foreach (var s in found) {
                Console.WriteLine("タイトルに「物語」が含まれているもの：" + s.Title);

            }
        }
    }
}
