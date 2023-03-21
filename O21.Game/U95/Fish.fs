﻿namespace O21.Game.U95.Fish

open System
open Microsoft.Xna.Framework.Graphics

type Fish = {
    Width: int
    Height: int
    LeftDirection: Texture2D[]
    RightDirection: Texture2D[]
    OnDying: Texture2D[]
}
    with
        interface IDisposable with
            member this.Dispose() =
                for t in this.RightDirection do
                    t.Dispose()
                for t in this.LeftDirection do
                    t.Dispose()
                for t in this.OnDying do
                    t.Dispose()
