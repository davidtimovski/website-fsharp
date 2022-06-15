module DavidTimovskiWebsite.Views.Home.TeamSketch

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Models
open DavidTimovskiWebsite.Views.Layout

let teamSketch (model : TeamSketchViewModel) =
    let pageTitle = "Team Sketch"

    ([
        div [ _id "team-sketch-page"
              _class "page" ] [
                div [ _class "banner" ] [
                    div [ _class "banner-wrap middle" ] [
                        header [ _class "banner-details" ] [
                            h1 [ _class "banner-title" ] [ rawText pageTitle ]
                            br []
                            p [] [ rawText "Share a canvas with your friends or random people." ]

                            ul [ _class "banner-links" ] [
                                li [] [
                                    a [ _href "https://github.com/davidtimovski/team-sketch"
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
                                p [] [ rawText "Create a room and connect with friends or join a random room and connect with a stranger. Share the canvas and show off your terrible drawing skills." ]
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
                                                a [ _href $"https://www.davidtimovski.com/downloads/team-sketch/team-sketch_{model.Version}_win64_setup.exe" ] [ rawText $"team-sketch_{model.Version}_win64_setup.exe" ]
                                            ]
                                            td [] [ rawText model.WindowsFileSize ]
                                        ]
                                    ]

                                    tbody [] [
                                        tr [] [
                                            td [ _rowspan "2" ] [ rawText "Debian, Ubuntu" ]
                                            td [] [ rawText "64-bit" ]
                                            td [] [
                                                a [ _href $"https://www.davidtimovski.com/downloads/team-sketch/team-sketch_{model.Version}_amd64.deb" ] [ rawText $"team-sketch_{model.Version}_amd64.deb" ]
                                            ]
                                            td [] [ rawText model.DebianUbuntu64FileSize ]
                                        ]
                                        tr [] [
                                            td [] [ rawText "ARM" ]
                                            td [] [
                                                a [ _href $"https://www.davidtimovski.com/downloads/team-sketch/team-sketch_{model.Version}_armhf.deb" ] [ rawText $"team-sketch_{model.Version}_armhf.deb" ]
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
