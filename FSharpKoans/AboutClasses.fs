namespace FSharpKoans

open FSharpKoans.Core

//---------------------------------------------------------------
// About Classes
//
// As a full fledged Object Oriented language, F# allows you to
// create traditional classes to contain data and methods.
//---------------------------------------------------------------

[<Koan(Sort = 21)>]
module ``about classes`` =

    type Zombie() =
        member this.FavoriteFood = "brains"

        member this.Eat food =
            match food with
            | "brains" -> "mmmmmmmmmmmmmmm... brains"
            | _ -> "grrrrrrrr"

    [<Koan>]
    let ClassesCanHaveProperties () =
        let zombie = Zombie()

        AssertEquality zombie.FavoriteFood "brains"

    [<Koan>]
    let ClassesCanHaveMethods () =
        let zombie = Zombie()

        let result = zombie.Eat "brains"
        AssertEquality result "mmmmmmmmmmmmmmm... brains"

    type Person(name: string) =
        member this.Speak() = "Hi my name is " + name

    [<Koan>]
    let ClassesCanHaveConstructors () =

        let person = Person("Shaun")

        let result = person.Speak()
        AssertEquality result "Hi my name is Shaun"

    type VerboseZombie() =
        let favoriteFood = "brains"

        member this.Eat food =
            if food = favoriteFood then
                $"mmmmmmmmmmmmmmm.. i like %s{favoriteFood}"
            else
                $"grrrrrrrr.. no like %s{food}"

    [<Koan>]
    let ClassesCanHaveLetBindingsInsideThem () =
        let zombie = VerboseZombie()

        let result = zombie.Eat "chicken"
        AssertEquality result "grrrrrrrr.. no like chicken"

    (* TRY IT: Can you access the let bound value Zombie2.favoriteFood
                   outside of the class definition? *)

    type RenamablePerson(name: string) =
        let mutable internalName = name
        let mutable phrase = "Hi my name is"

        member this.Name = internalName

        member this.Rename name =
            phrase <- "Hi. I've been renamed to"
            internalName <- name

        member this.Speak() =
            String.concat " " [ phrase; internalName ]

    [<Koan>]
    let ClassesCanHaveReadWriteProperties () =
        let person = RenamablePerson("Shaun")

        let firstPhrase = person.Speak()
        AssertEquality firstPhrase "Hi my name is Shaun"

        person.Rename "Shaun of the Dead"
        let secondPhrase = person.Speak()
        AssertEquality secondPhrase "Hi. I've been renamed to Shaun of the Dead"
