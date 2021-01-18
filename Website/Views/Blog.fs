module DavidTimovskiWebsite.Views.Blog

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Models
open DavidTimovskiWebsite.Views.Layout

let view (model : PostViewModel) =
    let pageTitle = model.Title

    ([
        div [ _class "page blog-page" ] [
            div [ _class "banner" ] [
                div [ _class "banner-wrap middle" ] [
                    header [ _class "banner-details" ] [
                        h1 [ _class "banner-title" ] [ rawText pageTitle ]
                        div [ _class "banner-subtitle" ] [ str model.Date ]
                    ]
                ]
            ]

            section [] [
                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        article [ _class "blog-post" ] [
                            section [ _class "body" ] [ rawText model.Body ]

                            footer [] [
                                if model.PreviousPostId.IsSome then
                                    a [ _class "previous"
                                        _title "Previous"
                                        _dataBind "attr: { href: previousPostUrl }" ] [
                                            i [ _class "icon-long-arrow-left" ] []
                                            span [] [ str model.PreviousPostTitle.Value ]
                                        ]
                                else span [] []

                                if model.NextPostId.IsSome then
                                    a [ _class "next"
                                        _title "Next"
                                        _dataBind "attr: { href: nextPostUrl }" ] [
                                            span [] [ str model.NextPostTitle.Value ]
                                            i [ _class "icon-long-arrow-right" ] []
                                        ]
                                else span [] []
                            ]
                        ]
                    ]
                ]
            ]
        ]

        let previousPostVars =
            if model.PreviousPostId.IsSome then
                $@"var previousPostId = '{model.PreviousPostId.Value}';
var previousPostTitle = '{model.PreviousPostTitle.Value}';"
            else ""

        let nextPostVars =
            if model.NextPostId.IsSome then
                $@"var nextPostId = '{model.NextPostId.Value}';
var nextPostTitle = '{model.NextPostTitle.Value}';"
            else ""

        script [] [ rawText (previousPostVars + nextPostVars) ]

    ], pageTitle, Blog) |> layout