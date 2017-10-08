# To1337

Your favorite .NET L337 tranzlator. Translates your strings into L337

```ps
PM > Install-Package To1337
```


## Simple usage
```cs
using To1337;

"Hello World!".To1337()
```
```cs
output > "H3ll0 W0rld!"
```

## Multiple levels of 1337ness supported:
1. Off
1. N00b
1. L337
1. H4rdC0r3H4xx0r

#### Example with set l337ness: 
```cs
"Hello World!".To1337(L337ness.H4rdC0r3H4xx0r)
```
