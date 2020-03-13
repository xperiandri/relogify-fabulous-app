//namespace Relogify

module Relogify.Routes

open Fabulous
open Xamarin.Forms

[<QueryProperty("Name", "name")>]
type RoutingPage(view: unit -> ViewElement) =
    inherit ContentPage()

    let mutable _name = ""
    let mutable _prevViewElement = None

    member this.Name
        with get() = _name
        and set(value: string) =
            _name <- value.Replace("%20", " ")
            this.Refresh()

    member this.Refresh() =
        let viewElement = view ()
        match _prevViewElement with
        | None ->
            this.Content <- viewElement.Create() :?> View
        | Some prevViewElement ->
            viewElement.UpdateIncremental(prevViewElement, this.Content)

type TimerRoutingPage() =
    inherit RoutingPage(Timer.init >> Timer.view)

//type DogRoutingPage() =
//    inherit RoutingPage(Dogs.data, (DogDetails.init >> DogDetails.view))
//type MonkeyRoutingPage() =
//    inherit RoutingPage(Monkeys.data, (MonkeyDetails.init >> MonkeyDetails.view))
//type ElephantRoutingPage() =
//    inherit RoutingPage(Elephants.data, (ElephantDetails.init >> ElephantDetails.view))
//type BearRoutingPage() =
//    inherit RoutingPage(Bears.data, (BearDetails.init >> BearDetails.view))
//
