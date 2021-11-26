module DavidTimovskiWebsite.Views.MyProjects

open Giraffe.ViewEngine
open DavidTimovskiWebsite.Views.Layout

let index =
    let pageTitle = "My Projects"

    ([
        div [ _class "page" ] [
                div [ _class "banner" ] [
                    div [ _class "banner-wrap middle" ] [
                        header [ _class "banner-details" ] [
                            h1 [ _class "banner-title" ] [ rawText pageTitle ]
                            br []
                            p [] [ rawText "Here I'm sharing the projects that I've done at home in my own free time. I've done a lot of work at home, some of it for convenience and some of it for learning purposes." ]
                        ]
                    ]
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Desktop applications" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Sapphire Notes" ]
                                    div [ _class "date" ] [ rawText "November, 2020" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "A cross-platform desktop application for managing notes" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "C#" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText ".NET Core" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Avalonia" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [
                                        span [] [ rawText "Wanted to take a swing at cross-platform desktop dev with this fairly obscure .NET framework " ]
                                        a [ _href "https://avaloniaui.net/" ] [ rawText "Avalonia" ]
                                        span [] [ rawText "." ]
                                    ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "/sapphire-notes" ] [
                                            i [ _class "icon-download" ] []
                                            span [] [ rawText "Download" ]
                                        ]
                                    ]
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
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Web applications" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Personal Assistant" ]
                                    div [ _class "date" ] [ rawText "October, 2019" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "An ecosystem of PWAs" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "C#/F#" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "ASP.NET Core" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "PostgreSQL" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Dapper.NET" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "RabbitMQ" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Linux (Ubuntu)" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Aurelia" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "TypeScript" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "SASS" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "PWA" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "IndexedDB" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "Wanted to learn more about PWAs and build something powerful enough that I myself will use every day." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://personalassistant.site"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "personalassistant.site" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/personal-assistant"
                                            _title "Source Code"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://www.davidtimovski.com/Blog/13/personal-assistant"
                                            _title "Blog article"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-file-text" ] []
                                            span [] [ rawText "Blog article" ]
                                        ]
                                    ]
                                ]
                            ]

                            hr [ _class "section-separator" ]

                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Smoke Tracker" ]
                                    div [ _class "date" ] [ rawText "October, 2021" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "Track your smoking habits" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "F#" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "ASP.NET Core" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "PostgreSQL" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Svelte" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "TypeScript" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "SASS" ]
                                    ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://smoketracker.davidtimovski.com"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "smoketracker.davidtimovski.com" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/smoke-tracker"
                                            _title "Source Code"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                    ]
                                ]
                            ]

                            hr [ _class "section-separator" ]

                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Metronome" ]
                                    div [ _class "date" ] [ rawText "July, 2021" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "Finally, a metronome that allows you to create and manage multiple tempos" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "TypeScript" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Svelte" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "SASS" ]
                                    ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://metronome.website"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "metronome.website" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/metronome"
                                            _title "Source Code"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                    ]
                                ]
                            ]

                            hr [ _class "section-separator" ]

                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Compound Interest Calculator" ]
                                    div [ _class "date" ] [ rawText "January, 2020" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "A compound interest calculator" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "C#" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Blazor (WebAssembly)" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Linux (Ubuntu)" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "PWA" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "Wanted to see the possibilities that a framework like Blazor (specifically WASM) offers." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://compoundinterest.davidtimovski.com"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "compoundinterest.davidtimovski.com" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/compound-interest-calculator"
                                            _title "Source Code"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                    ]
                                ]
                            ]

                            hr [ _class "section-separator" ]

                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Debt Resolver" ]
                                    div [ _class "date" ] [ rawText "March, 2017" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "Take debt and minimize the number of necessary transactions to resolve it" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "Aurelia" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "JavaScript (ES.Next)" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "SASS" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "Built this in order to better familiarize myself with ES.Next and Aurelia (my SPA framework of choice). Also, my first project with SASS. All in all, a great learning experience." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://debtresolver.davidtimovski.com"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "debtresolver.davidtimovski.com" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/debt-resolver"
                                            _title "Source Code"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-github" ] []
                                            span [] [ rawText "GitHub" ]
                                        ]
                                    ]
                                ]
                            ]

                            hr [ _class "section-separator" ]

                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "My Routine" ]
                                    div [ _class "date" ] [ rawText "March, 2016" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "Progress-tracking tool for people learning an instrument" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "C#" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "ASP.NET MVC" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "SQL Server" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Entity Framework" ]
                                        span [] [ rawText " , " ]
                                        span [ _class "item" ] [ rawText "Knockout.js" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "A progress-tracking tool for people learning an instrument. It allowed users to keep a flexible practice schedule regardless of what instrument they're learning." ]
                                    p [] [ rawText "A great UI that I'm unfortunately unable to show because it's an ASP.NET application, and I no longer host my apps on a Windows server." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/my-routine"
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
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Extensions" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Soccer Streamlined" ]
                                    div [ _class "date" ] [ rawText "October, 2017" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "A browser extension for live soccer streams" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "TypeScript" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "Made this in order to learn about browser extensions. Started building it in JavaScript but it quickly became unmanageable so I took the opportunity to learn TypeScript and I rewrote the whole thing. The difference in readability and maintainability was night and day." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "https://chrome.google.com/webstore/detail/soccer-streamlined/lcabedmhpejejhpjdfehcojabbdfihci"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "Chrome Web Store" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://addons.mozilla.org/en-US/firefox/addon/soccer-streamlined/"
                                            _title "Check it out"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-external-link-square" ] []
                                            span [] [ rawText "Firefox Add-ons" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/soccer-streamlined"
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
                ]

                section [] [
                    div [ _class "section-title" ] [ rawText "Libraries" ]
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                div [ _class "title-and-date" ] [
                                    div [ _class "title" ] [ rawText "Temporal.js" ]
                                    div [ _class "date" ] [ rawText "November, 2015" ]
                                ]

                                p [ _class "subtitle" ] [ rawText "Yet another JavaScript library for handling dates" ]

                                div [ _class "tech-list" ] [
                                    h4 [] [ rawText "Tech" ]
                                    p [] [
                                        span [ _class "item" ] [ rawText "TypeScript" ]
                                    ]
                                ]

                                div [ _class "goal" ] [
                                    h4 [] [ rawText "Goal" ]
                                    p [] [ rawText "A JavaScript library for handling dates. It is less than a quarter of the size of Moment.js and it can do pretty much all the things developers usually use Moment.js for." ]
                                    p [] [ rawText "I developed it when I was a junior developer to better familiarize myself with (the pitfalls of) the JavaScript Date object." ]
                                ]

                                ul [ _class "links" ] [
                                    li [] [
                                        a [ _href "/my-projects/temporal"
                                            _title "Documentation"
                                            _target "_blank"
                                            _rel "noopener" ] [
                                            i [ _class "icon-file-text" ] []
                                            span [] [ rawText "Documentation" ]
                                        ]
                                    ]
                                    li [] [
                                        a [ _href "https://github.com/davidtimovski/temporal"
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
                ]
            ]
    ], pageTitle, MyProjects) |> layout


let temporal = 
    let pageTitle = "Temporal.js"

    ([
        div [ _id "temporal-page"
              _class "page" ] [
                div [ _class "banner" ] [
                    div [ _class "banner-wrap middle" ] [
                        header [ _class "banner-details" ] [
                            h1 [ _class "banner-title" ] [ rawText pageTitle ]
                            br []
                            p [] [
                                span [] [ rawText "Yet another JavaScript library for handling dates. I am well aware of the existence of " ]
                                a [ _href "http://momentjs.com/" ] [ rawText "Moment.js" ]
                                span [] [ rawText ". I did this solely as a learning project and I learned a lot. All things aside though, it's a pretty usable library. It's less than a quarter of the size of Moment.js and it can do pretty much all the things we usually use Moment.js for." ]
                            ]
                        ]
                    ]
                ]

                section [] [
                    div [ _class "middle" ] [
                        div [ _class "section-content" ] [
                            div [ _class "section-item" ] [
                                p [] [
                                    span [] [ rawText "Calling the " ]
                                    code [ _class "incline-code" ] [ rawText "temporal()" ]
                                    span [] [ rawText " function returns the temporal object with the current time: " ]

                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText "temporal();" ]
                                    ]
                                    p [] [ rawText "The temporal object attempts to parse the value sent to it:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05'); // string
temporal(1438725600000); // number - as milliseconds
temporal([2015, 7, 5, 18, 5, 7, 123]); // array - in the order of year, month, day, hour, minute, second, millisecond
temporal(new Date()); // JavaScript Date
temporal(temporal()); // another Temporal object" ]
                                    ]

                                    p [] [ rawText "When invoking with a string argument Temporal attempts to parse the date by a number of common formats. Here are some working examples:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05');
temporal('2015/08/05 18:05');
temporal('2015-08-05T18:05:07');
temporal('2015.08.05 18:05:07.123');" ]
                                    ]

                                    p [] [ rawText "If the date string cannot be parsed the exact format should be specified with a second argument like so:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('04-17-2015 12:25 PM', '[MM]-[dd]-[yyyy] [hh]:[mm] [tt]');" ]
                                    ]

                                    br []

                                    h3 [] [ rawText "Formatting" ]

                                    p [] [ rawText "An essential function one cannot do without is the format function:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"('2015-08-05').format(); // Thursday, August 05, 2015" ]
                                    ]

                                    p [] [ rawText "The format method accepts a string parameter for specifying the exact format you want your date to appear in:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05:07').format('[dd]/[MM]/[yyyy] [HH]:[mm]:[ss]'); // 05/08/2015 18:05:07" ]
                                    ]

                                    p [] [ rawText "Here's the full list of available tokens:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05:07.123').format('[y], [yy], [yyy], [yyyy]'); // 5, 15, 015, 2015
temporal('2015-08-05 18:05:07.123').format('[M], [MM], [MMM], [MMMM]'); // 8, 08, Aug, August
temporal('2015-08-05 18:05:07.123').format('[d], [dd], [do]'); // 5, 05, 5th
temporal('2015-08-05 18:05:07.123').format('[H], [HH], [h], [hh]'); // 18, 18, 6, 06
temporal('2015-08-05 18:05:07.123').format('[m], [mm]'); // 5, 05
temporal('2015-08-05 18:05:07.123').format('[s], [ss]'); // 7, 07
temporal('2015-08-05 18:05:07.123').format('[f], [ff], [fff]'); // 1, 12, 123
temporal('2015-08-05 18:05:07.123').format('[t], [tt]'); // P, PM" ]
                                    ]

                                    p [] [ rawText "Having the tokens in brackets allows for clear separation between tokens and regular text:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05').format('On the [do] of [MMMM] [yyyy] the weather was quite nice');
// On the 5th of August 2015 the weather was quite nice" ]
                                    ]

                                    br []

                                    h3 [] [ rawText "Querying" ]

                                    p [] [ rawText "Get any time part:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05:07.123').year(); // 2015
temporal('2015-08-05 18:05:07.123').month(); // 7
temporal('2015-08-05 18:05:07.123').day(); // 5
temporal('2015-08-05 18:05:07.123').hour(); // 18
temporal('2015-08-05 18:05:07.123').minute(); // 5
temporal('2015-08-05 18:05:07.123').second(); // 7
temporal('2015-08-05 18:05:07.123').millisecond(); // 123" ]
                                    ]

                                    p [] [ rawText "Get a relative time string, a common necessity in web applications:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05:07').relativeTimeString();
// X years, X days, X hour, X minutes and X seconds ago" ]
                                    ]

                                    p [] [ rawText "The same method accepts a parameter to specify the precision (hour, minute or second) with the default precision being in seconds:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05:07').relativeTimeString('hour');
// X years, X days and X hour ago
temporal('2015-08-05 18:05:07').relativeTimeString('minute');
// X years, X days, X hour and X minutes ago" ]
                                    ]

                                    p [] [ rawText "Get other stuff:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal().monthName(); // January
temporal().monthName('short'); // Jan
temporal().weekdayName(); // Friday
temporal().weekdayName('short'); // Fri
temporal().isLeapYear(); // false
temporal().timeZoneOffset(); // -60" ]
                                    ]

                                    br []

                                    h3 [] [ rawText "Modification" ]

                                    p [] [ rawText "Set any time part:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal().years(2015).months(7).days(5).hours(18).minutes(5).seconds(7).milliseconds(123);" ]
                                    ]

                                    p [] [ rawText "Add to any time part:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal().addYears(5);
temporal().addMonths(1);
temporal().addWeeks(2);
temporal().addDays(10);
temporal().addHours(2);
temporal().addMinutes(15);
temporal().addSeconds(10);
temporal().addMilliseconds(250);" ]
                                    ]
                                    
                                    p [] [ rawText "Subtract from any time part:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal().subtractYears(5);
temporal().subtractMonths(1);
temporal().subtractWeeks(2);
temporal().subtractDays(10);
temporal().subtractHours(2);
temporal().subtractMinutes(15);
temporal().subtractSeconds(10);
temporal().subtractMilliseconds(250);" ]
                                    ]

                                    p [] [ rawText "Advance to tomorrow or go back to yesterday:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal().tomorrow().format('will be the [do]');
temporal().yesterday().format('was the [do]');" ]
                                    ]

                                    br []

                                    h3 [] [ rawText "Comparison" ]

                                    p [] [ rawText "To get the difference between two dates:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-12').difference(temporal('2015-08-05')); // 604800000" ]
                                    ]

                                    p [] [ rawText "To check if a date is before or after another date:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-12').isBefore(temporal('2015-08-05')); // false
temporal('2015-08-12').isAfter(temporal('2015-08-05')); // true" ]
                                    ]

                                    p [] [ rawText "Both of the above methods accept a second parameter to specify the precision (year, month, day, hour, minute, or second) with the default being in milliseconds:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-12').isAfter(temporal('2015-08-05'), 'month'); // false
temporal('2015-08-12').isAfter(temporal('2015-08-05'), 'day'); // true" ]
                                    ]

                                    p [] [ rawText "Get a person's age by their birthday:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText "temporal('1991-08-10').age(); // 29" ]
                                    ]

                                    br []

                                    h3 [] [ rawText "Conversion" ]

                                    p [] [ rawText "A temporal object can also be converted:" ]
                                    pre [] [
                                        code [ _class "language-javascript" ] [ rawText @"temporal('2015-08-05 18:05').toJSDate(); // Thu Aug 05 2015 18:05:00 GMT+0200 (Central European Daylight Time)
temporal('2015-08-05 18:05').toArray(); // [2015, 7, 5, 18, 5, 0, 0]
temporal('2015-08-05 18:05').toMilliseconds(); // 1438790700000" ]
                                    ]
                                ]
                            ]
                        ]
                    ]
                ]
            ]
    ], pageTitle, None) |> layout