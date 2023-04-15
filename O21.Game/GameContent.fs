namespace O21.Game

open System
open System.IO
open Raylib_CsLo
open Microsoft.FSharp.NativeInterop

#nowarn "9"

type GameContent = {
    UiFont: Font
} with
    static member Load(): GameContent = 
        let workingDir = Path.GetDirectoryName(Environment.ProcessPath)
        let pathToResource fileName =
            Path.Combine(workingDir, "Resources", fileName)
        let fontChars = [|
            for i in 0..95 -> 32 + i // Basic ASCII characters
            for i in 0..255 -> 0x400 + i // Cyrillic characters 
        |]
        use ptr = fixed fontChars
        {
            UiFont = Raylib.LoadFontEx(pathToResource "CozetteVector.ttf", 13, ptr, fontChars.Length)
        }
