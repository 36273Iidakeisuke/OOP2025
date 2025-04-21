namespace ProductSample {
    internal class Program {
        static void Main(string[] args) {

            Product karinto = new Product(123, "かりんとう", 180);


            //税抜きの価格を表示
            Console.WriteLine(karinto.Name + "の税抜き価格は" + karinto.Price + "です。");
            //消費税額の表示
            Console.WriteLine(karinto.Name + "の消費税額は" + karinto.GetTax() + "です。"); 
            //税込み価格の表示
            Console.WriteLine(karinto.Name + "の税込み価格は" + karinto.GetPriceIncludingTax()  + "です。");
        }
    }
}