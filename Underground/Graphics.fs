namespace Underground

open System.Drawing

module Colours =
    let district = Color.FromArgb (0, 157, 38)
    let circle = Color.FromArgb (255, 211, 41)
    let metropolitan = Color.FromArgb (155, 0, 88)
    let waterloo = Color.FromArgb (147, 206, 186)
    let victoria = Color.FromArgb (0, 152, 216)
    let jubilee = Color.FromArgb (161, 165, 167)
    let central = Color.FromArgb (220, 36, 31)
    let bakerloo = Color.FromArgb (178, 99, 0)
    let hammersmith = Color.FromArgb (244, 169, 190)
    let piccadilly = Color.FromArgb (55, 73, 176)
    let elizabeth = Color.FromArgb (147, 100, 204)
    let overground = Color.FromArgb (239, 123, 16)
    let dlr = Color.FromArgb (0, 175, 173)
    let northern = Color.White
    let trams = district
    let airline = central

    let textColour = northern
    let highlightColour = hammersmith
    let accentColour = jubilee

module Fonts =
    let cosmic = "cosmic.flf"
    let isometric = "isometric1.flf"
    let ogre = "ogre.flf"
    let slant = "slant.flf"
    let small = "small.flf"
    let smallIsometric = "smisome1.flf"
    let smallScript = "smscript.flf"
    let smallSlant = "smslant.flf"
    let smallShadow = "smshadow.flf"
    let speed = "speed.flf"