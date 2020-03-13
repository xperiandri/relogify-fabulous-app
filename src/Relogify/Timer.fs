module Relogify.Timer

open Fabulous.XamarinForms
open Xamarin.Forms

type Model =
    { TimeLeftMs: int }

let init () = { TimeLeftMs = 60 * 1000 }

let view model =
    View.ContentPage(
        title = "Timer",
        content =
            View.StackLayout(
                 padding = Thickness 20.0,
                 verticalOptions = LayoutOptions.Center,
                 children =
                     [
                          View.Label(
                              text = sprintf "Time left: %d" model.TimeLeftMs,
                              horizontalOptions = LayoutOptions.Center,
                              width = 200.0,
                              horizontalTextAlignment = TextAlignment.Center)
                     ]
                )
        )
