using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {

            var lines
                =
                File
                    .
                     ReadAllText
                (
                    "s"     +

                        "a"     +

                            "m"     +

                        "p"     +

                    "l"     +

                        "e"     +

                            "."     +

                        "t"     +

                    "x"     +

                        "t"

                )
                ;

            //問題11-4
            var newlines 
                = 
                Regex
                     .
                      Replace
                (
                    lines,
                    @"(V|v)ersion\s*=\s*""v4\.0""",
                    @"version=""v5.0"""
                )
                ;

            File
                .
                 WriteAllText
                (
                    "s"     +   
                    
                        "a"     +

                            "m"     +

                                "p"     +

                    "l"     +

                        "e"     +

                            "C"     +

                                "h"     +

                    "a"     +

                        "n"     +

                            "g"     +

                                "e"     +

                    "."     +

                        "t"     +

                            "x"     +

                                "t"
                    , 
                    newlines
                )
                ;

            //これ以降は確認用
            var text 
                =
                File
                    .
                     ReadAllText
                (
                    "sample"    +
                    "Change."   +
                    "txt"
                )
                ;
            Console
                   .
                    WriteLine
                (
                    text
                )
                ;
        }
    }
}
