# Final-Project-Assignment
## POD <br/>
### ความเป็นมาของโปรแกรม
อยากขาย สินค้าเครื่องประดับที่มีแบนด์อย่างถูกต้องตามกฎหมาย

<br/> <br/>
### วัตถุประสงค์ของโปรแกรม
1.อยากทำโปรแกรมขาย ขายสินค้าเครื่องประดับ <br/>
2.อยากพัฒนาโปรแกรมขาย เครื่องประดับตกแต่ง <br/>



<br/><br/>
### โครงสร้างของโปรแกรม
```mermaid 
classDiagram
    Program <-- From1
    From1 <-- Poduck
    From1 <-- Accessories
    Program : +Main()
    class From1{
        +openToolStripMenuItem1_Click()
        +button1_Click()
        +saveToolStripMenuItem_Click()
        +button3_Click()
        +printDocument1_PrintPage()
    }
    class Poduck{
        +pocket()
        +watch()
        +bathingsui()
        +sneaker()
    }
    
    }
    class Accessories{
        +Gucci()
        +Balenciaga()
        +Fendi()
        +Versace()
    }
 ```
    <br/> <br/>
### ผู้พัฒนาโปรแกรม
นายอภิทุน ดวงจันทร์คล้อย 643450092-1
