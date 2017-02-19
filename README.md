reading The Stanford Question Answering Dataset Document (context )

json file structure:

data : 0 - 441 object 
      data : 0 - N 
            title 
            paragraphs: 0 - M 
                      context   
                      some question

this code is about extracting the context of each data element to a seperate file 
by compining paragraphs in each data element in c#
using Newtonsoft.Json;
