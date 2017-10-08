# To1337

Your favorite .NET L337 tranzlator. Translates your strings into L337

## Installation
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

## Output Examples

### Input

```
The beginner couldn't believe how cool this is. It rocks!
```


### N00b
```
Th3 noob c0uldn't b3l13v3 how w00t th1s 15. I7 rocks!
```

### L337
```
Th3 n00b c0uldn't b3l13v3 h0w w00t th12 is. I+ r0ck20r y0ur 80x0r2s!
```
### H4rdC0r3H4xx0r
```
T]-[3 |\|00ß ©()µl|)|/|'7 bel1e\/e |-|0\/\/ \/\/00+ t|-|15 15. It |2o(kz0|2 yo|_||2 |3ox0|2zs!
```
