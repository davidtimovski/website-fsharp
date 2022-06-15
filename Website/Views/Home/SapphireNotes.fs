module DavidTimovskiWebsite.Views.Home.SapphireNotes

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Models
open DavidTimovskiWebsite.Views.Layout

let sapphireNotes (model : SapphireNotesViewModel) =
    let pageTitle = "Sapphire Notes"

    ([
        div [ _id "sapphire-notes-page"
              _class "page" ] [
                div [ _class "banner" ] [
                    div [ _class "banner-wrap middle" ] [
                        header [ _class "banner-details" ] [
                            h1 [ _class "banner-title" ] [ rawText pageTitle ]
                            br []
                            p [] [ rawText "Prettier than Notepad and snappier than Electron alternatives." ]

                            ul [ _class "banner-links" ] [
                                li [] [
                                    a [ _href "https://github.com/davidtimovski/sapphire-notes"
                                        _title "Source Code"
                                        _target "_blank"
                                        _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                ]
                            ]
                        ]
                    ]
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Features" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                p [] [ rawText "Create and manage notes. Wow!" ]
                                p [] [
                                    span [] [ rawText "All of them are stored as simple " ]
                                    code [ _class "inline-code" ] [ rawText ".txt" ]
                                    span [] [ rawText " files so if you decide to stop using the app you'll still have your notes in a format you can use anywhere, even on a Mac." ]
                                ]
                                p [] [ rawText "The application auto-saves in frequent intervals and also when closed, so you won't have to do Ctrl/Command+S. You probably still will though because of habit." ]
                                p [] [ rawText "Easily archive notes you're currently not using." ]
                                p [] [ rawText "Where the notes are stored is your choice. If you want them to be backed up you can simply choose your OneDrive or DropBox folder as the storage location and voilà, cloud backup!" ]
                                p [] [ rawText "There are many hotkeys and actions that can improve your efficiency in using the app and make you feel like a hax0r. Check them out in Help -> Tips." ]
                            ]
                        ]
                    ]
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Download" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                div [ _class "download-table-title" ] [
                                    div [] [ rawText $"Version {model.Version}" ]
                                    div [ _class "release-date" ] [ rawText model.ReleaseDate ]
                                ]

                                table [] [
                                    thead [] [
                                        tr [] [
                                            th [] [ rawText "Platform" ]
                                            th [] [ rawText "Architecture" ]
                                            th [] [ rawText "Download Link" ]
                                            th [] [ rawText "File Size" ]
                                        ]
                                    ]
                                    
                                    tbody [] [
                                        tr [] [
                                            td [] [ rawText "Windows" ]
                                            td [] [ rawText "64-bit" ]
                                            td [] [
                                                a [ _href $"https://www.davidtimovski.com/downloads/sapphire-notes/sapphire-notes_{model.Version}_win64_setup.exe" ] [ rawText $"sapphire-notes_{model.Version}_win64_setup.exe" ]
                                            ]
                                            td [] [ rawText model.WindowsFileSize ]
                                        ]
                                    ]

                                    tbody [] [
                                        tr [] [
                                            td [ _rowspan "2" ] [ rawText "Debian, Ubuntu" ]
                                            td [] [ rawText "64-bit" ]
                                            td [] [
                                                a [ _href $"https://www.davidtimovski.com/downloads/sapphire-notes/sapphire-notes_{model.Version}_amd64.deb" ] [ rawText $"sapphire-notes_{model.Version}_amd64.deb" ]
                                            ]
                                            td [] [ rawText model.DebianUbuntu64FileSize ]
                                        ]
                                        tr [] [
                                            td [] [ rawText "ARM" ]
                                            td [] [
                                                a [ _href $"https://www.davidtimovski.com/downloads/sapphire-notes/sapphire-notes_{model.Version}_armhf.deb" ] [ rawText $"sapphire-notes_{model.Version}_armhf.deb" ]
                                            ]
                                            td [] [ rawText model.DebianUbuntuARMFileSize ]
                                        ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
              ]
    ], pageTitle, None) |> layout
