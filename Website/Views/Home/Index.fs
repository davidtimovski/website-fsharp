module DavidTimovskiWebsite.Views.Home.Index

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Views.Layout
open DavidTimovskiWebsite.Renderers

let index =
    ([
        div [ _class "page home-page" ] [ 
            
            div [ _class "banner" ] [
                div [ _class "banner-wrap middle" ] [
                    div [ _class "banner-image-wrap" ] [
                        img [ _src "/images/profile.webp" 
                              _class "banner-image"
                              _alt "A picture of me" ]
                    ]

                    header [ _class "banner-details" ] [
                        h1 [ _class "banner-title" ] [ rawText "David Timovski" ]
                        div [ _class "job-title" ] [ rawText ".NET Full-Stack Developer" ]
                        
                        p [ _class "contact-detail" ] [ rawText "Current location:" ]
                        span [] [ rawText "Prague, Czech Republic" ]

                        p [ _class "contact-detail" ] [ rawText "Contact:" ]
                        span [] [
                             rawText "Me on "
                             a [ _href "https://www.linkedin.com/in/davidtimovski"
                                 _target "_blank"
                                 _rel "noopener" ] [ rawText "LinkedIn" ]
                        ]

                        div [ _class "site-version" ] [
                            span [] [ rawText "The coin has been flipped." ]
                            br []
                            span [] [ rawText "You got the " ]
                            a [ _href "https://github.com/davidtimovski/website-fsharp"
                                _target "_blank"
                                _rel "noopener" ] [ rawText "F# version" ]
                            span [] [ rawText " of this website." ]
                        ]
                    ]
                ]
            ]

            section [ _class "grey-section" ] [
                div [ _class "social-icons-wrap middle" ] [
                    div [ _class "social-icons" ] [
                        a [ _href "https://www.linkedin.com/in/davidtimovski"
                            _class "icon-linkedin"
                            _title "LinkedIn"
                            _target "_blank"
                            _rel "noopener" ] []
                        a [ _href "https://github.com/davidtimovski"
                            _class "icon-github"
                            _title "GitHub"
                            _target "_blank"
                            _rel "noopener" ] []
                        a [ _href "https://stackoverflow.com/users/1200185/alternatex"
                            _class "icon-stack-overflow"
                            _title "Stack Overflow"
                            _target "_blank"
                            _rel "noopener" ] []
                        a [ _href "https://wellfound.com/u/david-timovski"
                            _class "icon-angellist"
                            _title "Wellfound"
                            _target "_blank"
                            _rel "noopener" ] []
                    ]
                ]
            ]

            section [ _class "grey-section" ] [
                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        div [ _class "intro-title" ] [ rawText "Hello there!" ]
                        div [ _class "intro-text" ] [ rawText "I'm a .NET Developer (usually) focused on web applications. I love learning and there's always something to learn in this industry. I program at work and then I program at home. All sides of the stack." ]
                    ]
                ]
            ]

            section [] [
                div [ _class "section-title-with-subtitle" ] [
                    div [ _class "title-part" ] [ rawText "Expertise" ]
                    div [ _class "subtitle-part" ] [ rawText "No need to sift through, just ask." ]
                ]

                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        h3 [ _class "expertise-question" ] [
                            span [] [ rawText "Do you know" ]
                            span [ _class "expertise-question-input-wrap" ] [
                                input [ _type "text"
                                        _dataBind "attr: { placeholder: expertisePlaceholder }, textInput: expertiseQuery" ]
                                span [] [ rawText " ?" ]
                            ]
                        ]

                        div [ _dataBind "foreach: foundExpertise, hidden: expertiseNotFound"
                              _class "expertise-answers" ] [
                            div [ _class "expertise-item" ] [
                                div [ _class "expertise" ] [
                                    img [ _dataBind "attr: { src: imageSrc }"
                                          _class "expertise-image" ]
                                    div [ _class "expertise-content" ] [
                                        div [ _class "expertise-title" ] [
                                            div [ _class "expertise-tech-wrap" ] [
                                                span [ _dataBind "text: tech"
                                                       _class "expertise-tech" ] []
                                                span [ _class "expertise-tech-triangle" ] []
                                            ]
                                            div [ _dataBind "text: answer"
                                                  _class "expertise-answer" ] []
                                        ]

                                        div [ _dataBind "html: description"
                                              _class "expertise-description" ] []
                                    ]
                                ]

                                div [ _class "expertise-matched-tags" ] [
                                    span [] [ rawText "Matched: " ]
                                    span [ _dataBind "foreach: matchedTags" ] [
                                        span [ _dataBind "text: $data"
                                               _class "expertise-tag" ] []
                                    ]
                                ]
                            ]
                        ]

                        div [ _dataBind "visible: expertiseNotFound"
                              _class "expertise-not-found" ] [ rawText "Sorry, couldn't find anything about that" ]
                    ]
                ]
            ]

            section [] [
                div [ _class "section-title" ] [ rawText "Work experience" ]

                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.microsoft.com" ] [ rawText "Microsoft (Teams Free)" ]
                                ]
                                div [ _class "date" ] [ rawText "May, 2025 - Present" ]
                            ]

                            techList [ "C#"; ".NET Framework/8"; "ASP.NET (Core)"; "Cosmos DB"; "Azure Event Hubs"; "Azure Cache for Redis"; "Azure Key Vault"; "Azure Service Bus"; ]
                       
                            div [ _class "description" ] [
                                p [] [ rawText "Working on more or less the same things as before." ]
                            ]
                        ]
                        
                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.skype.com" ] [ rawText "Microsoft (Skype)" ]
                                ]
                                div [ _class "date" ] [ rawText "October, 2022 - May, 2025" ]
                            ]

                            techList [ "C#"; ".NET Framework/8"; "ASP.NET (Core)"; "Cosmos DB"; "Azure Event Hubs"; "Azure Cache for Redis"; "Azure Key Vault"; "Azure Service Bus"; "Azure Cloud Services" ]
                       
                            div [ _class "description" ] [
                                p [] [ rawText "Well we all know how that turned out.." ]
                                p [] [ rawText "Jokes aside, worked on back-end services handling user accounts, reputation, user settings, meetings, and various other flows (too many to mention) that were essential to the functioning of the Skype client." ]
                            ]
                        ]
                        
                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://learningally.org" ] [ rawText "Learning Ally" ]
                                ]
                                div [ _class "date" ] [ rawText "May, 2021 - September, 2022" ]
                            ]
                        
                            techList [ "C#"; "SQL Server"; "WCF"; "Entity Framework" ]
                        
                            div [ _class "description" ] [
                                p [] [ rawText "Through the Toptal contracting platform." ]
                                p [] [ rawText "Helped refactor and expand their web services (WCF) with new functionality and also assisted with maintenance on the main website. Additionally spent time on the support side, integrating new districts/schools into the application as well as investigating and fixing customer reported issues at the database level." ]
                            ]
                        ]
                        
                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.kaloncreative.com" ] [ rawText "Kalon Creative" ]
                                ]
                                div [ _class "date" ] [ rawText "January, 2021 - May, 2021" ]
                            ]
                        
                            techList [ "C#"; "ASP.NET"; "SQL Server"; "Entity Framework"; "JavaScript"; "jQuery" ]
                        
                            div [ _class "description" ] [
                                p [] [ rawText "Through the Toptal contracting platform." ]
                                p [] [ rawText "Worked mostly on adding functionality to a large web application that deals with organizing and managing events, including virtual (live stream) ones." ]
                            ]
                        ]
                        
                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://perceptivesol.com" ] [ rawText "Perceptive Solutions (WoundZoom)" ]
                                ]
                                div [ _class "date" ] [ rawText "August, 2020 - December, 2020" ]
                            ]

                            techList [ "C#"; "ASP.NET"; "SQL Server"; "Entity Framework"; "Hangfire"; "Azure API for FHIR"; "JavaScript"; "AngularJS" ]

                            div [ _class "description" ] [
                                p [] [ rawText "My first Toptal client. A company that deals with wound imaging, documentation, and analysis. My first task was creating a dashboard with interactive charts that showed a high-level overview of patient and wound data." ]
                                p [] [ rawText "Afterwards, I developed a solution that will allow multiple clients with separate databases to use a single hosted instance of the web application (multi-tenancy)." ]
                                p [] [ 
                                    span [] [ rawText "My biggest challenge came last when I worked to integrate the client's application with the " ]
                                    a [ _href "https://hl7.org/FHIR/" ] [ rawText "HL7 FHIR" ]
                                    span [] [ rawText " standard for health care data exchange." ]
                                ]
                            ]
                        ]

                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.nebb.com" ] [ rawText "Nebb Solutions" ]
                                ]
                                div [ _class "date" ] [ rawText "January, 2018 - February, 2020" ]
                            ]

                            techList [ "C#"; "ASP.NET Core"; "WCF"; "WPF"; "Entity Framework (Core)" ]

                            div [ _class "description" ] [
                                p [] [ rawText "I worked on an enterprise application that deals with network planning for the telecom industry. My job revolved around developing and maintaining Restful APIs that provided additional functionalities and third-party integrations to the main desktop application." ]
                                p [] [ rawText "I also spent much of my time developing a collection of internal libraries for efficient packaging and reading of network coverage data." ]
                                p [] [ rawText "Our team was distributed (Macedonia/Norway) and Scrum based." ]
                            ]
                        ]

                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.opengi.co.uk" ] [ rawText "Open GI" ]
                                ]
                                div [ _class "date" ] [ rawText "December, 2016 - December, 2017" ]
                            ]

                            techList [ "C#"; "ASP.NET"; "SQL Server"; "Entity Framework"; "JavaScript"; "Durandal.js" ]

                            div [ _class "description" ] [
                                p [] [ rawText "I was a part of a distributed (Macedonian/English) team that worked on a large web application for managing insurance claims. We followed a strict Scrum methodology that helped us remain organized." ]
                                p [] [ rawText "My daily work included full-stack development with all of the technologies listed above. We used Visual Studio Team Services to track our progress and we did code reviews to keep the technical debt to a minimum." ]
                            ]
                        ]

                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [
                                    a [ _href "https://www.arthaus.mk" ] [ rawText "ArtHaus" ]
                                ]
                                div [ _class "date" ] [ rawText "March, 2014 - December, 2016" ]
                            ]

                            techList [ "C#"; "ASP.NET MVC"; "ASP.NET Web Forms"; "SQL Server"; "Entity Framework"; "PHP"; "Laravel"; "MySQL"; "JavaScript"; "jQuery" ]

                            div [ _class "description" ] [
                                p [] [ rawText "Worked on small to medium sized web applications built in PHP/MySQL or ASP.NET MVC/SQL Server. My responsibilities involved both back and front-end, sometimes including design. I worked extensively with CSS, JavaScript and jQuery and I also developed a plugin/theme pair for WordPress." ]
                            ]
                        ]
                    ]
                ]
            ]

            section [] [
                div [ _class "section-title" ] [ rawText "Education" ]

                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [ rawText "European University - Republic of Macedonia" ]
                                div [ _class "date" ] [ rawText "2010 - 2013" ]
                            ]

                            div [ _class "subtitle" ] [ rawText "Bachelor of Software Engineering (B.SE.)" ]

                            div [ _class "description" ] [
                                p [] [ rawText "I built multiple applications while I was a student and did a ton of essays as additional learning material." ]
                                p [] [ rawText "My graduation project was a web application for auctioning written in PHP. The purpose was to explain all of the technologies involved in building a web application, from designing the database to writing the back-end code." ]
                            ]
                        ]
                    ]
                ]
            ]

            section [] [
                div [ _class "section-title" ] [ rawText "Honors & certifications" ]

                div [ _class "middle" ] [
                    div [ _class "section-content" ] [
                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [ rawText "Professional Scrum Master I" ]
                                div [ _class "date" ] [ rawText "May 2018" ]
                            ]

                            div [ _class "subtitle" ] [ rawText "Scrum.org" ]

                            div [ _class "description" ] [
                                p [] [
                                    span [] [ rawText "Earned the certificate by passing the Professional Scrum Master I assessment at " ]
                                    a [ _href "https://www.scrum.org/" ] [ rawText "Scrum.org" ]
                                    span [] [ rawText ". Doing so required a fundamental understanding of the theory behind Scrum as well as ways of applying it in the real world." ]
                                ]
                            ]

                            ul [ _class "links" ] [
                                li [] [
                                    a [ _href "/downloads/PSM I.pdf" ] [
                                        i [ _class "icon-file-text" ] []
                                        span [] [ rawText "Certificate" ]
                                    ]
                                ]
                                li [] [
                                    a [ _href "https://www.scrum.org/user/353345"
                                        _title "Profile at Scrum.org"
                                        _target "_blank"
                                        _rel "noopener" ] [
                                        i [ _class "icon-external-link-square" ] []
                                        span [] [ rawText "Profile" ]
                                    ]
                                ]
                            ]
                        ]

                        hr [ _class "section-separator" ]

                        div [ _class "section-item" ] [
                            div [ _class "title-and-date" ] [
                                div [ _class "title" ] [ rawText "Student scholarship" ]
                                div [ _class "date" ] [ rawText "February 2013" ]
                            ]

                            div [ _class "subtitle" ] [ rawText "Macedonian Ministry of Education and Sciences" ]

                            div [ _class "description" ] [
                                p [] [ rawText "During my third year of IT studies, I was awarded a student scholarship of type B for students doing bachelor studies. The scholarship was awarded on the basis of an 8.1 grade average." ]
                            ]
                        ]
                    ]
                ]
            ]
        ]
    ], "Home", Home) |> layout
