# ProefProeve
Proef PvB

## Contribution
### Code Conventions
 * Enter Bracket
 * Folders are UpperCamelCase.
 * __No one letter variables.__
 * __No public variables, use properties.__
 
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
 * Use underscores before private variable names to increase readability.
 * One `namespace` for entire project.
 * Utils use a seperate `namespace`.
 * Warnings should be treated as errors.
 * Always commit a working build.
 * Always add protection level to method/variable.

## Contributors
Joost Voss, Dejorden Moerman, Sander de Boer, Angelina Medu, Jesse Stam, Petar Dimitrov.
