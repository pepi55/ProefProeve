# ProefProeve
Proef PvB

## Contribution
### Code Conventions
 * Enter Bracket
 * No public variables, use properties.
 
 Auto generated:
 ```C#
 public int Foo { get; set; }
 ```
 
 User generated:
 ```C#
 private int bar;
 public int Bar
 {
     get
     {
         return value;
     }
 
      set
     {
         bar = value;
     }
 }
 ```
 * Initialization on one line. (i.e. `[SerializeField] private int variable;`)
 * Unity methods are protected. (i.e. `protected void Awake()`)
 * `Awake()` is for initialization, `Start()` is for assigning variables.
 * No underscores before variable names because we don't use public variables.
