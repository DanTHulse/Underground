namespace UndergroundTest

open Microsoft.VisualStudio.TestTools.UnitTesting

open Underground
open Underground.TrainData
open Underground.StationData

[<TestClass>]
type DataTests () =

    [<TestMethod>]
    member __.FindTrainByIdReturnsTrain () =
        let trainId = 1
        let train = findTrainById (trainId)

        Assert.AreEqual(trainId, train.id)

    [<TestMethod>]
    member __.FindLinesForStationReturnsLines () =
        let station = findStationById (35)
        let lines = findLinesForStation (station)

        Assert.IsFalse(lines |> List.isEmpty)

    [<TestMethod>]
    member __.FindStationByIdReturnsStation () =
        let stationId = 35
        let station = findStationById (stationId)

        Assert.AreEqual(stationId, station.id)

    [<TestMethod>]
    member __.FindNexStationReturnsNextStationForTrain () =
        let stationId = 35
        let nextStationId = 245
        let trainId = 1

        let station = findStationById (stationId)
        let train = findTrainById (trainId)
        let (nextStation, _) = findNextStation (station, train)

        Assert.AreEqual(nextStationId, nextStation.id)

    [<TestMethod>]
    member __.FindNexStationReturnsCurrentStationIfNoMoreStationsOnRoute () =
        let stationId = 35
        let trainId = 2

        let station = findStationById (stationId)
        let train = findTrainById (trainId)
        let (nextStation, _) = findNextStation (station, train)

        Assert.AreEqual(stationId, nextStation.id)

    [<TestMethod>]
    member __.TerminusReturnsTrueIfStationIsTerminusOfRoute () =
        let stationId = 35
        let trainId = 2

        let station = findStationById (stationId)
        let train = findTrainById (trainId)
        let termini = terminus (station, train)

        Assert.IsTrue(termini)

    [<TestMethod>]
    member __.TerminusReturnsFalseIfStationIsNotTerminusOfRoute () =
        let stationId = 35
        let trainId = 1

        let station = findStationById (stationId)
        let train = findTrainById (trainId)
        let termini = terminus (station, train)

        Assert.IsFalse(termini)