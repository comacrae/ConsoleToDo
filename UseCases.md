# Use Cases
This is a jot pad for what I want interactions with taskli to look like. May turn into documentation in the future.

### Adding A Task

```
>> taskli add -t "code today" -l "listname"
>> "code today" added to list "listname"

>> taskli add --task "code today" --list "My List"
>> "code today" added to tasklist "My List"

>> taskli add "code today" "code tomorrow" "code this weekend" -l "My List"
>> 3 tasks added to "My List"

>> taskli add "buy cat litter"

```

```
>> taskli add "My newest task" -l 
>> No tasklist named "My Nonexistent List" exists. Create one? [Y]es [N]o: Y
>> Tasklist "My Nonexistent List" created. Add tasks? [Y]es [N]o: Y
>> Enter tasks below (one per line). Press CTRL+D or enter empty line to complete:
>> Task Numba One
>> Task Numba Two
>> my third task!
>> 3 tasks added to "My Nonexistent List"
```

### Undo Most Recent Action
```
taskli undo
```



