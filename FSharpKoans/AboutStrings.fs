namespace FSharpKoans

open FSharpKoans.Core

//---------------------------------------------------------------
// About Strings
//
// Most languages have a set of utilities for manipulating
// strings. F# is no different.
//---------------------------------------------------------------
[<Koan(Sort = 7)>]
module ``about strings`` =

    [<Koan>]
    let StringValue () =
        let message = "hello"

        AssertEquality message "hello"

    [<Koan>]
    let StringConcatValue () =
        let message = "hello " + "world"

        AssertEquality message "hello world"

    [<Koan>]
    let FormattingStringValues () =
        let message =
            sprintf "F# turns it to %d!" 11

        AssertEquality message "F# turns it to 11!"
        printf "%s%i%f%b%A" "N" 7 3.14 true (1, 2, 3)

    //NOTE: you can use printf to print to standard output

    (* TRY IT: What happens if you change 11 to be something besides
                   a number? *)

    [<Koan>]
    let FormattingOtherTypes () =
        let message = sprintf "hello %s" "world"

        AssertEquality message "hello world"

    [<Koan>]
    let FormattingAnything () =
        let message =
            $"Formatting other types is as easy as: %A{(1, 2, 3)}"

        AssertEquality message "Formatting other types is as easy as: (1, 2, 3)"

    (* NOTE: For all the %formatters that you can use with string formatting
             see: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/plaintext-formatting *)

    [<Koan>]
    let CombineMultiline () =
        let message =
            "super\
                cali\
                fragilistic\
                expiali\
                docious"

        AssertEquality message "supercalifragilisticexpialidocious"

    [<Koan>]
    let Multiline () =
        let message =
            "This
                is
                on
                five
                lines"

        AssertEquality
            message
            "This
                is
                on
                five
                lines"

    [<Koan>]
    let ExtractValues () =
        let message = "hello world"

        let first = message.[0]
        let other = message.[4]

        (* A single character is denoted using single quotes, example: 'c',
        not double quotes as you would use for a string *)

        AssertEquality first 'h'
        AssertEquality other 'o'

    [<Koan>]
    let ApplyWhatYouLearned () =
        (* It's time to apply what you've learned so far. Fill in the function below to
           make the asserts pass *)

        let power (x: int) = (pown x 2, pown x 3)

        let funFactsAbout x =
            let p2, p3 = power x
            $"%i{x} to the power of 2 is %i{p2}, and %i{x} to the power of 3 is %i{p3}!"

        AssertEquality "3 to the power of 2 is 9, and 3 to the power of 3 is 27!" (funFactsAbout 3)
        AssertEquality "6 to the power of 2 is 36, and 6 to the power of 3 is 216!" (funFactsAbout 6)
