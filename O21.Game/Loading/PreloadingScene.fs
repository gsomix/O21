namespace O21.Game.Loading

open type Raylib_CsLo.Raylib

open O21.Game

type PreloadingScene() =

    interface ILoadingScene<unit, LocalContent> with
        member this.Init _ = ()
        member this.Load _ = LocalContent.Load()

        member _.Update(_, _) = ()
        member _.Draw() = ClearBackground(BLACK)
