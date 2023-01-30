# Big Integer Example
BigInt implementation ported from old C code

## Operations 
- Addition 
- Subtraction 
- Multiplication 
- Division 
- Modulo

## Usage:
### Initialize:
```csharp
var number = new BigInt(1234);
```
Or
```csharp
BigInt number = 1234;
```
Same with strings:
```csharp
BigInt number = "-123456789";
```
### Add:
```csharp
var result = new BigInteger("123456789") + 123456L;
result += "999999";
```
### Sub:
```csharp
var result = new BigInteger("123456789") - 123456L;
result -= "999999";
```
### Mul:
```csharp
var result = new BigInteger("123456789") * 123456L;
result *= "999999";
```
### Div:
```csharp
var result = new BigInteger("123456789") / 123456L;
result /= "2";
```
### Mod:
```csharp
var result = new BigInteger("123456789") % 123456L;
result %= "2";
```
### CompareTo:
```csharp
var result = new BigInteger("123456789").CompareTo("12345676");
```