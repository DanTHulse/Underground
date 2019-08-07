namespace Underground

[<AutoOpen>]
module DomainTypes =
    type Lines =
      | Northern = 0
      | Circle = 1
      | District = 2
      | HammersmithCity = 3
      | Metropolitan = 4
      | Central = 5
      | Jubilee = 6
      | Bakerloo = 7
      | Victoria = 8
      | Piccadilly = 9
      | WaterlooCity = 10
      | Elizabeth = 11
      | DLR = 12
      | Overground = 13
      | Trams = 14
      | AirLine = 15
      | Walking = 16
    
    type Train = {
      id: int
      lineId: Lines
      line: string
      destination: string
      nightTube: bool
    }

    type Route = {
      station: int
      trains: int[]
      fullTrains: Train list
      weight: int
    }

    type Station = {
      id: int
      name: string
      routes: Route list
    }