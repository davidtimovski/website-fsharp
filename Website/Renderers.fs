module DavidTimovskiWebsite.Renderers

open System.Collections.Generic
open Giraffe.ViewEngine

let techList (items) =
    let nodes =
        items |>
        Seq.map (fun x -> 
           span [ _class "item" ] [ rawText x ]
        ) |>
        Seq.toList
    
    let outputList = List<XmlNode>()
    for i in 1 .. nodes.Length - 1 do
        outputList.Add(nodes[i])
        outputList.Add(span [] [ rawText " , " ])

    outputList.Add(nodes[nodes.Length - 1])

    div [ _class "tech-list" ] [
        h4 [] [ rawText "Tech" ]
        p [] (Seq.toList outputList)
    ]
