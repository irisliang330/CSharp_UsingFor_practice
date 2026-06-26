# **for 迴圈**

- **迴圈之基本要素**
    - 控制變數初值設定 `int i = 1`
    - 檢驗條件 `i<=100`
    - 控制變數改變 `i++`
- **常見錯誤**
    - 邊界值錯誤 Off-by-one error
        - `i<100` `i≤101` 之類的
    - 無窮迴圈：跳不出來，有時候會有意如此
        - ex `++i` 寫成 `++sum`

為了反覆計算
數學家高斯
special function

**讓電腦1加到10**

```csharp
int sum = 1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10; 
// 太慢了

int sum = 0; 
sum += 1;
sum += 2;
sum += 3;
sum += 4;
sum += 5;
sum += 6;
sum += 7;
sum += 8;
sum += 9;
sum += 10;
// 還是很慢
// 只有右邊在改變 -> for 迴圈
```

```csharp
int sum = 0;
for (int i = 0; i < 100; i++)
{
    sum += i;
}

Console.WriteLine("1~100的加總=" + sum);
// 1~100的加總=4950
```

迴圈控制變數`i` 

!image.png

在.NET偵錯裡面可以設中斷點去看for迴圈怎麼跑
i到100之前都會一直加

!image.png

!image.png

<aside>
💡

**練習**

**修改範例程式UsingFor，計算1到100的偶數和**

</aside>

```csharp
// 計算1加到100
int sum = 0;
for (int i = 1; i <= 100; i++)
{
    sum += i;
}

Console.WriteLine("1~100的加總=" + sum);
// 1~100的加總=4950 XX -> 寫錯成i<100
// 1~100的加總=5050
```

```csharp
// 計算1到100的偶數和
int sumEven = 0;
for (int i = 0; i <= 100; i += 2)
{
    sumEven += i;
}

Console.WriteLine("1~100的偶數和=" + sumEven);
// 1~100的偶數和=2450 XX -> 寫錯成i<100
// 1~100的偶數和=2550
// i必須是從0開始，初始i若是1會被納入計算，1無法被2整除
// 一開始卡在條件寫成 i<100 && i%2==0
```

!image.png

## **以`Debug.Assert()`偵測邊界值錯誤**

```csharp
using System.Diagnostics;
// == 系統診斷，放在using System;下面 ==

// == main{}裡面 ==
// Debug.Assert() 偵測邊界值錯誤
int i;
int sumTest = 0;
// 要測試的條件

Debug.Assert(sumTest == 0);
for (i = 1; i < 100; ++i)
{
    sumTest += i;
}

Debug.Assert(i == 101);
// i==101就會跳出來

---- DEBUG ASSERTION FAILED ----
---- Assert Short Message ----
i == 101
---- Assert Long Message ----
```

## 九九乘法表

相乘的兩個數i j
i的for迴圈裡面放j的for迴圈

```csharp
// 04_九九乘法表_Mtable
int i;
int j;

// Array MTable = [i, j];
// XX no need for Array

int MVaule = 0;

for (i = 1; i <= 9; i++)
{
    for (j = 1; j <= 9; j++)
    {
        MVaule = i * j;
        // MVaule += i*j; -> XX MVaule will change
        // Console.WriteLine(MVaule);
        Console.WriteLine($"{i}x{j}={MVaule}");
        // forget ${} -> search
    }
    // Console.WriteLine(MVaule); -> start from 9
}
```

!image.png

```csharp
// Answer

for (i = 1; i < 10; ++i)
{
    for (j = 1; j < 10; ++j)
    {
        Console.Write("{0}*{1}={2} ",
        i, j, i * j);
    }
    // 印完一組便換行
    Console.WriteLine();
}
```

- 迴圈中不改變的敘述 → 不會隨著i改變但執行很多次→ 效率障礙
- 編譯建置過程的最佳化
- 兩種版本的CIL檔 → Common Intermediate Language 通用中間語言
    
    !image.png
    
- Release → 要快，改變寫法不改變用意，但不好debug
- Debug → 偵錯用code