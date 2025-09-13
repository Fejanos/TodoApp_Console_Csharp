# TodoApp

A simple **C# .NET console application** to manage tasks (Todo list).  
Built as a beginner-friendly project to practice **CRUD operations, file storage, and clean code structure**.

---

## ✨ Features
- Add, list, delete, and toggle completion of tasks
- Persistent storage with **JSON file**
- Clean **OOP structure** with separate folders:
  - `/Models` → data classes (e.g., `TodoItem`)
  - `/Services` → business logic (`TodoServices`)
  - `/Data` → file handling (`FileStorage`)
- Table-style formatted console output
- Fully commented code (easy to read for beginners)

---

## 🚀 How to Run

Open terminal in VS Code (`` Ctrl+` ``) or PowerShell, then:
```bash
dotnet run
```

---

## Example session
```bash
=== TODO LIST APP ===
1. Add task
2. Show tasks
3. Delete task
4. Toggle complete
5. Save and Exit

Choose an option: 2

-------------------------------------------------
ID    Status     Title
-------------------------------------------------
1     [ ]        Buy milk
2     [X]        Finish project report
3     [ ]        Call mom
-------------------------------------------------
```

---

## 📂 JSON file format (todos.json)
Tasks are stored in JSON and automatically loaded/saved:
```bash
[
  { "Id": 1, "Title": "Buy milk", "IsCompleted": false },
  { "Id": 2, "Title": "Finish project report", "IsCompleted": true },
  { "Id": 3, "Title": "Call mom", "IsCompleted": false }
]
```

---

### Common pitfalls
- ✅ `dotnet run` → works fine, reads/writes `todos.json`
- ❌ Forgetting to copy `todos.jso`n → shows "File not found"
- Place `todos.jso`n next to the compiled program in `bin/Debug/net9.0/`

### Roadmap
- ✅ CRUD operations
- ✅ JSON persistence
- ✅ Table-style console output
- ✅ Clean OOP structure
- ❌ Colored console output (e.g., green for completed tasks)
- ❌ Task due dates & priorities
- ❌ Unit tests with xUnit
- ❌ Export tasks to CSV/Markdown