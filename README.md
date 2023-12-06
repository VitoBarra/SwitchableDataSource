# Disclaimer
This project is NOT ready for production use; it is in an embryonal stage and requires further work and redesign, so use it at your own risk

Also, there is no documentation. It will arrive when I will be happy with the state of the project

# SwitchableDataSource

This is a little framework that I implemented during a University Project.

The main goal is to AutoMenage Writing and Reading from Data Sources and transfers data from one kind of source to another one in an easy and clean manner

An example:
You have your data on JSON files and if you want to transfer all this data to another format like CSV, MongoDB, or SQLDB, NO Problem.
You need to create your implementation of the reader for Json and your implementation of the writer for one of your other preferred formats, select a memorization strategy with the option that best suits you and you are good to go.

Obviously, it also works for the same kind of format as json->json. In this way, you can have an AutoMenaged Read/Write from your data format. 

There is some Default implementation for common uses, like
- AutoSaving
that's it.

performance:
- Every strategy is implemented in a multithreaded environment to ensure good performance. Including AutoSave.

Possibilities:
- You can switch the source Dinamycaly during runtime 
- MemorizationStrategy is extendible if you have some particular need.



Code Example:
