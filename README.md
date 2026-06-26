# **4. for 迴圈**

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

## 九九乘法表 巢狀for迴圈

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

# 5. While 迴圈

```csharp
int sum =0;
int i =1;

while (i <= 100) // 檢驗是否合乎迴圈執行的條件
{
    sum+-i;      // 要在迴圈裡做的事放while{}
    ++i;
}

Console.WriteLine("1~100的加總等於"+sum);
```

!image.png

for 迴圈：控制變數初值設定，檢驗執行條件，控制變數修改
從流程圖可見，控制變數初值設定＆控制變數修改分別在迴圈外跟迴圈內，我們只要去檢驗迴圈執行的條件就行

- **使用時機：**
    - 迴圈繼續執行之條件比較複雜
    - 很不容易以一個控制變數表現迴圈繼續執行之條件
        - ex 檔案讀取未結束→檔案指標沒到最後就繼續執行讀檔
- **常見錯誤：**
    - 控制變數未設初值 → while{}只包條件 很容易忘記初值
    - 迴圈內控制變數未改變
    - 無窮迴圈 → 只寫條件忘記寫控制變數修改 `i`永遠一樣跑不出來

### **無窮級數計算**

求算 $S = \sum_{0}^{\infty} a_n$

```csharp
const double THRESHOLD = 1.0e-8; //準確位數要求
double sum = 0;

int n = 0;
double term = 相當於a0 的計算式;

while (Math.Abs(term) > THRESHOLD) 
{
    sum += term;
    ++n;
    term = 相當於an 的計算式;
}
```

`Math.Abs(term)`：計算 `term`（當前項）的**絕對值，**級數的每一項可能是正數也可能是負數（例如 $1 - \frac{1}{2} + \frac{1}{4} - \frac{1}{8}$），取絕對值可以確保我們只關心這個數字的大小，不受正負號影響

`> THRESHOLD`：大於**門檻值**（或稱容許誤差），通常是一個極小的數字 ex `0.000001` ($10^{-6}$)

- Ai 詳解
    
    ### 1. 準備階段（設定門檻與初始值）
    
    ```csharp
    const double THRESHOLD = 1.0e-8; //準確位數要求
    double sum = 0;
    ```
    
    - **`THRESHOLD = 1.0e-8`**：這是科學記號法的 $1.0 \times 10^{-8}$，也就是 `0.00000001`。這代表我們要求的**精準度門檻**。
    - **`sum = 0`**：用來儲存累積總和的變數，一開始沒加任何東西，所以是 0。
    
    ### 2. 計算第一項 $a_0$
    
    ```csharp
    int n = 0;
    double term = 相當於a0 的計算式;
    ```
    
    - **`n = 0`**：從第 0 項開始編號。
    - **`term`**：代表「當前要被加進去的那一項」。這裡先算出級數的第一項 $a_0$ 的數值。
    
    ### 3. 核心循環（重複加總，直到數字小到看不見）
    
    ```csharp
    while (Math.Abs(term) > THRESHOLD)
    {
        sum += term;
        ++n;
        term = 相當於an 的計算式;
    }
    ```
    
    這個 `while` 迴圈會一直重複執行以下三件事，直到條件不滿足：
    
    1. **`sum += term;`**：把剛剛算好的這一項，加進總和 `sum` 裡面。
    2. **`++n;`**：準備計算下一項，所以項數 `n` 加 1（變成 1, 2, 3...）。
    3. **`term = ...;`**：根據新的 `n`，算出下一項 $a_n$ 的數值。
    
    **什麼時候會停下來？**
    
    當程式一直加、一直加，加到某一個 $a_n$ 的數值極小，其絕對值 `Math.Abs(term)` **小於或等於 `0.00000001`** 時，`while` 的條件就會變成不成立（False）。
    
    這時電腦就知道：「後面剩下的數字都太小了，加了也沒差」，於是跳出迴圈。
    最後的 `sum` 就是這個無窮級數非常精準的近似解。
    

# 6. do-while 迴圈

先執行變數改變再做條件檢驗

```csharp
// 06_1加到100的do-while寫法
int sum = 0;
int i = 1;

do
{ //迴圈繼續執行的條件
    sum += i;
    ++i;
} while (i <= 100);

Console.WriteLine("1~100的加總等於" + sum);
```

!image.png

| 比較項目 | `for` | `while` | `do...while` |
| --- | --- | --- | --- |
| 適合情境 | **已知要執行幾次** | **不知道要執行幾次** | **至少要執行一次** |
| 條件檢查 | **先檢查** | **先檢查** | **最後才檢查** |
| 最少執行次數 | 0 次 | 0 次 | **1 次** |
| 初始化 | 寫在 `for` 裡 | 通常寫在外面 | 通常寫在外面 |
| 遞增/遞減 | 寫在 `for` 裡 | 自己寫 | 自己寫 |
| 使用情境 | 九九乘法表
印 1~100
陣列走訪 | 等待使用者輸入正確資料
持續讀取檔案直到結束
遊戲主迴圈 | 至少顯示一次選單
至少詢問一次使用者輸入 |

# **7. `continue`與`break`**

**continue：**略過該次迴圈、直接執行下一次迴圈
**break：**終止迴圈、直接跳出迴圈不再繼續執行

**畢氏數**

$x^2 + y^2 = z^2$

前10組畢氏數:
(3, 4, 5)、(5, 12, 13)、(6, 8, 10)、(7, 24, 25)、(8, 15, 17)、(9, 12, 15)、(9, 40, 41)、(10, 24, 26)、(11, 60, 61)、(12, 16, 20)

```csharp
// Pythagoras.Program
int x;
int y;
int z;
int n = 0;  //迴圈外面要有 n=0; 起始值

for (x = 1; x <= 100; ++x). // x其實到12就好，但你寫程式的時候不一定知道 100是預估
{
    for (y = x; y <= 100; ++y) // 避免345 543 y直接從x開始 
    {
        for (z = 1; z <= 150; ++z) // z^2=x^2+y^2 去估值 抓個整數
        {
            
            if (x * x + y * y == z * z) // 條件檢查：是否符合畢氏數 C#沒有平方要用*
            {
                ++n;
                if (n <= 10) // 前10組
                {
                    Console.WriteLine(
                    "{0}: {1}*{1} + {2}*{2} = {3}*{3}", // 由小而大排列
                    n, x, y, z);
                }
            }
        }
    }
}

output:
1: 3*3 + 4*4 = 5*5
2: 5*5 + 12*12 = 13*13
3: 6*6 + 8*8 = 10*10
4: 7*7 + 24*24 = 25*25
5: 8*8 + 15*15 = 17*17
6: 9*9 + 12*12 = 15*15
7: 9*9 + 40*40 = 41*41
8: 10*10 + 24*24 = 26*26
9: 11*11 + 60*60 = 61*61
10: 12*12 + 16*16 = 20*20

```

因為只要找10組，但範圍寫到100，即便已經找到了for迴圈還是會繼續跑 → 浪費
`n = 10`的時候要跳開迴圈

## `break` 只跳離目前所在的那一層

```csharp
//UsingBreak.Program

for (x = 1; x <= 100; ++x)
{
    for (y = x; y <= 100; ++y)
    {
        for (z = 1; z <= 150; ++z)
        {
            if (x * x + y * y == z * z)
            {
                ++n;
                Console.WriteLine(
                "{0}: {1}*{1} + {2}*{2} = {3}*{3}",
                n, x, y, z);
                break;  // 只有一個z可以滿足x^2+y^2=z^2 找到就跳開z迴圈
            }
        }
        if (n == 10) break;  //n到10了 跳開y迴圈
    }
    if (n == 10) break;  //n到10了 跳開x迴圈
}
```

code 還是不太清爽 → 要怎麼讓它少掉一個`{}` → if改成`if (x * x + y * y != z * z)`

## continue 下面的事情不用做

```csharp
// UsingContinueAndBreak.Program

for (x = 1; x <= 100; ++x)
{
    for (y = x; y <= 100; ++y)
    {
        for (z = 1; z <= 150; ++z)
        {
            if (x * x + y * y != z * z) continue; // continue代表接下去的事情不用執行
            ++n;
            Console.WriteLine("{0}: {1}*{1} + {2}*{2} = {3}*{3}", n, x, y, z);
            break;
        }
        if (n == 10) break;
    }
    if (n == 10) break;
}

```