# ProefProeve
Proef PvB

## Contribution
### Code Conventions
 * Enter Bracket
 * No public variables, use properties.
 
 Auto generated:
 ```C#
 public int Variable { get; set; }
 ```
 
 User generated:
 ```C#
 private int _variable_;
 public int _Variable_
 {
     get
     {
         return value;
     }
 
      set
     {
         variable = value;
     }
 }
 ```
 * Initialization on one line. (i.e. `[SerializeField] private int variable;`)
 * Unity methods are protected. (i.e. `protected void Awake()`)
 * `Awake()` is for initialization, `Start()` is for assigning variables.
