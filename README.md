<div align="center">

### Siren
Una collezione di utility usati nei plugin Dalamud di FFXIVITA.

**[Issues](https://github.com/ffxivita/Siren/issues) · [Pull Requests](https://github.com/ffxivita/Siren/pulls)**

</div>

## Importante

Siren è stata sviluppata per essere usata con i plugin di FFXIVITA e ovviamente contiene il mio modo di scrivere e le mie scelte di design (che ovviamente vengono tutte commentate accuratamente). Le Pull requests sono le benvenute per inserire nuove funzionalità finchè esse non vegano usate per cheatare o botting.

I cambiamenti possono essere fatti in qualunque momento. Usando Siren accetti implicitamente che dovrai potrai aver bisogno di cambiare molto il tuo codice qualora agigornassi il submodulo. Non posso garantire stabilità al momento.

## About

Siren è una collezione di utilities (una "common library") che è pensata per essere usata con i plugin Dalamud. Contiene metodi di estensioni, componenti ed elementi di ImGui, e altre utilità che potrebbero mancare da Dalamud/FFXIVClientStructs.

## Installazione

Siren deve essere usata come submodule dentro al tuo repository. Per aggiungere Siren come submodule, esegui questo comando dentro il tuo repository git:

```bash
git submodule add https://github.com/ffxivita/Siren.git
```

Aggiornare Siren:

```bash
git submodule update --remote
```

## Uso

**Devi** inizializzare Siren prima di poter usare quello che ha da offrirti. Puoi farlo richiamando il metodo  `Initialize`. È raccomandato l'uso dentro al proprio costruttore del plugin.

Dovrai anche usare il dispose di Siren quando il tuo plugin non viene caricato. Puoi farlo richiamando il metodo `Dispose`. È raccomandato l'uso dentro al metodo dispose del proprio plugin.

```csharp
using Siren;

public class MioPlugin : IDalamudPlugin
{
    public string Name => "MioPlugin";

    public MioPlugin(DalamudPluginInterface pluginInterface)
    {
        SirenCore.Initialize(pluginInterface, Name);
    }

    public void Dispose()
    {
        Siren.Dispose();
    }
}
```