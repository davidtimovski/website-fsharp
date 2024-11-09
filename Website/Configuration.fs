module Configuration

[<CLIMutable>]
type DatabaseOptions =
    {
        DefaultConnectionString : string
    }

[<CLIMutable>]
type SapphireNotesOptions =
    {
        Version : string
        ReleaseDate : string
        WindowsFileSize : string
        DebianUbuntu64FileSize : string
        DebianUbuntuARMFileSize : string
    }

[<CLIMutable>]
type TeamSketchOptions =
    {
        Version : string
        ReleaseDate : string
        WindowsFileSize : string
        DebianUbuntu64FileSize : string
        DebianUbuntuARMFileSize : string
    }
