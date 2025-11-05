namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            HttpClient hc = 
            GetHtmlExample(  );
        }

        static async Task GetHtmlExample(HttpClient httpClient) {
            var url = "https://www.yahoo.co.jp";
            var text = await httpClient.GetStringAsync(url);
            Console.WriteLine(text);
        }

    }
}
