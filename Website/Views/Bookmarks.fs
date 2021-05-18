module DavidTimovskiWebsite.Views.Bookmarks

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Models
open DavidTimovskiWebsite.Views.Layout

let view (model : List<Bookmark>) =
    let pageTitle = "Bookmarks"

    ([
        div [ _class "page" ] [
            div [ _class "banner" ] [
                div [ _class "banner-wrap middle" ] [
                    header [ _class "banner-details" ] [
                        h1 [ _class "banner-title" ] [ rawText pageTitle ]
                        br []
                        p [] [ rawText "There's a ton of interesting articles, videos, and tools out there on the web. These are the ones that I felt were worth bookmarking." ]
                    ]
                ]
            ]

            section [] [
                div [ _class "middle" ] [
                    div [ _class "section-content bookmarks" ] [
                        let bookmarkToHtml (bookmark : Bookmark) = div [] [
                            a [ _href bookmark.Url
                                _target "_blank"
                                _rel "noopener" ] [

                                    match bookmark.Type with 
                                    | BookmarkType.Article -> i [ _class "icon-file-text" ] []
                                    | BookmarkType.Video -> i [ _class "icon-play-circle" ] []
                                    | BookmarkType.Tool -> i [ _class "icon-briefcase" ] []
                                    | _ -> ()

                                    span [] [ str bookmark.Title ]    
                                    span [ _class "author" ] [ str bookmark.Author ]
                                    div [ _class "clear" ] []
                            ]
                            hr []
                        ]

                        div [] (List.map bookmarkToHtml model)
                    ]
                ]
            ]
        ]
    ], pageTitle, Bookmarks) |> layout