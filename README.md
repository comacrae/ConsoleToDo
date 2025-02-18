# Console To Do With Parser

## A CLI Task Management App
A command line interface to-do app that saves/loads task lists using JSON. No CLI libraries used - everything made from scratch:
* tokenizer
* parser
* command and option classes
* validation classes

### Installation

Download the ConsoleToDoProject.exe file found in ConsoelToDoProject/ConsoleToDoProject/bin/Debug/net8.0

### Supported commands

#### help
View commands and options
```
help
```

#### print
Print current task list
```
print
```
#### load
Load task file
```
load
-p --path (required)
```
#### save
Save current task file
```
save
-p --path (required)
```
#### add
Add task to list with designated priority (1-3)
```
add
-p --priority
```
#### remove
Remove matching task(s)
```
remove
-a --all (remove all tasks)
-p --priority (remove task matching given priority)
-c --completed (remove completed tasks)
-d --description (remove task matching given description)
```
#### update
Update matching task
```
update
--p --priority (remove task matching given priority)
-d --description (remove task matching given description)
```
#### quit
quit app
```
quit
```
