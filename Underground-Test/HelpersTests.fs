namespace UndergroundTest

open Microsoft.VisualStudio.TestTools.UnitTesting

open Underground

[<TestClass>]
type HelpersTests () =

    [<TestMethod>]
    member __.JoinCombinesStrings () =
        let expected = "Test, Test2, Test3"

        let joined =
            [
                "Test"
                "Test2"
                "Test3"
            ]
            |> join

        Assert.AreEqual(expected, joined)

    [<TestMethod>]
    member __.FullLineNameReturnsEnumNameForDefault () =
        let northern = Lines.Northern |> fullLineName

        Assert.AreEqual("Northern", northern)

    [<TestMethod>]
    member __.FullLineNameReturnsFullLineName () =
        let handc = Lines.HammersmithCity |> fullLineName

        Assert.AreEqual("Hammersmith & City", handc)