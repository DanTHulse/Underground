namespace Underground

[<AutoOpen>]
module DomainTypes =
    type Lines =
        Northern = 0
      | Circle = 1
      | District = 2
      | HammersmithCity = 3
      | Metropolitan = 4
      | Central = 5
      | Jubilee = 6
      | Bakerloo = 7
      | Victoria = 8
      | Piccadily = 9
      | WaterlooCity = 10
      | Elizabeth = 11
      | DLR = 12
      | Overground = 13
      | Trams = 14
      | AirLine = 15
      | Walking = 16
    
    type Directions =
        Northbound = 'n'
      | Southbound = 's'
      | Eastbound = 'e'
      | Westbound = 'w'