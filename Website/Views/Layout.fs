module DavidTimovskiWebsite.Views.Layout

open System
open Giraffe.ViewEngine

type ActiveNavItem = 
    | Home
    | MyProjects
    | Blog
    | Bookmarks
    | None

let _dataBind = attr "data-bind"
let _as = attr "as"

let layout (content: XmlNode list, pageTitle: string, activeNavItem: ActiveNavItem) =
    html [ _lang "en-US" ] [
        head [] [
            meta [ _name "description"
                   _content ".NET Full-Stack Developer" ]
            meta [ _charset "utf-8" ]
            meta [ _name "viewport"
                   _content "width=device-width, initial-scale=1.0" ]
            meta [ _name "google-site-verification"
                   _content "17RRbP81BHFtIxOvAMrm87BdWATSWAQ3kIcwKzW9ZCw" ]
            
            link [ _rel "icon" 
                   _href "/favicon.png" ]
            title [] [ rawText $"{pageTitle} - David Timovski" ]

            link [ _rel "preconnect"
                   _href "https://fonts.googleapis.com"
                   _crossorigin "" ]
            link [ _rel "preconnect"
                   _href "https://fonts.gstatic.com"
                   _crossorigin "" ]
            link [ _rel "stylesheet"
                   _href "https://fonts.googleapis.com/css?family=Rubik&display=swap" ]

#if DEBUG
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/reset.css" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/responsive.gs.12col.css" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/icons.css" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/prism.css" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/main.css" ]
#else
            link [ _rel  "preload"
                   _href "/css/style.min.css?v=2"
                   _as "style" ]
            link [ _rel  "stylesheet"
                   _type "text/css"
                   _href "/css/style.min.css?v=2" ]
#endif
            ]

        body [] [
            div [ _id "wrap" ] [
                main [ _id "content" ] [
                    header [ _id "header" ] [
                        nav [] [
                            a [ _href "/"
                                _class ( if activeNavItem = Home then "active" else "" )
                             ] [ rawText "Home" ]
 
                            a [ _href "/my-projects"
                                _class ( if activeNavItem = MyProjects then "active" else "" )
                            ] [ rawText "My Projects" ]
 
                            a [ _href "/blog"
                                _class ( if activeNavItem = Blog then "active" else "" )
                            ] [ rawText "Blog" ]
 
                            a [ _href "/bookmarks"
                                _class ( if activeNavItem = Bookmarks then "active" else "" )
                            ] [ rawText "Bookmarks" ]
                        ]
                    ]

                    div [] content

                    footer [ _id "footer" ] [
                        div [ _class "middle" ] [ rawText $"Copyright &copy; {DateTime.Now.Year} David Timovski" ]
                    ]
                ]
            ]

            script [ _src "https://cdnjs.cloudflare.com/ajax/libs/knockout/3.5.1/knockout-latest.js" ] []
            script [ _src "https://cdnjs.cloudflare.com/ajax/libs/velocity/2.0.6/velocity.min.js" ] []
            script [ _src "https://cdnjs.cloudflare.com/ajax/libs/prism/1.23.0/prism.min.js" ] []

#if DEBUG
            script [ _src "/js/home.js" ] []
            script [ _src "/js/blog.js" ] []
#else
            script [ _src "/js/scripts.min.js" ] []
#endif
        ]
    ]