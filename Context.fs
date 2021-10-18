namespace FSEFCore

open System
open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore

 [<CLIMutable>]
 type Foo =
    { [<Key>]Id: Guid
      Name: string
      Bar: int }


type Context (opt) =
    inherit DbContext(opt)

      [<DefaultValue>] val mutable foos : DbSet<Foo>
      member this.Foos with get() = this.foos
                        and set v = this.foos <- v
      override _.OnModelCreating builder =
        //builder.RegisterOptionTypes()
        builder.ApplyConfigurationsFromAssembly(typedefof<Context>.Assembly) |> ignore
        base.OnModelCreating(builder)
