namespace O21.Game

open System
open System.IO
open System.Threading.Tasks

open Raylib_CsLo

/// The game content that's always available locally, even if the main game resources haven't been downloaded, yet.
type LocalContent = {
    UiFontRegular: Font
    UiFontBold: Font
    LoadingTexture: Texture
    SoundFontPath: string
} with
    static member Load(): Task<LocalContent> = task {
        let binDir = Path.GetDirectoryName(Environment.ProcessPath)
        let pathToResource fileName =
            Path.Combine(binDir, "Resources", fileName)
        let fontChars = [|
            for i in 0..95 -> 32 + i // Basic ASCII characters
            for i in 0..255 -> 0x400 + i // Cyrillic characters
            yield int '…'
        |]
        let fontSize = 24

        let loadFont path = task {
            let! data = File.ReadAllBytesAsync(path)
            return RaylibUtils.LoadFontFromMemory (Path.GetExtension path) data fontSize fontChars
        }

        let loadTexture path = task {
            let! data = File.ReadAllBytesAsync(path)
            return RaylibUtils.LoadTextureFromMemory (Path.GetExtension path) data
        }

        let! regular = loadFont <| pathToResource "Fonts/Inter-Regular.otf"
        let! bold = loadFont <| pathToResource "Fonts/Inter-Bold.otf"
        let! loading = loadTexture <| pathToResource "submarine.png"

        return {
            UiFontRegular = regular
            UiFontBold = bold
            LoadingTexture = loading
            SoundFontPath = pathToResource "SoundFont/microgm.sf2"
        }
    }
