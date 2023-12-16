# Disclaimer
This project is currently in its early stages of development and is not recommended for production use. It requires further refinement and redesign, so proceed at your own risk. Documentation will be provided once the project reaches a satisfactory state.

# Purpose of This Framework

The SwitchableDataSource framework aims to simplify the management of data interactions, including reading and writing operations to a data source. It provides a platform where you need to write minimal code to interact with the data source. Additionally, it offers an easy way to compose multiple data sources and manage migrations between them.

This framework provides an abstraction of the data, allowing you to treat the object as a "source" of data without concerning yourself with the details of how it is read and written.

The goal is to be flexible and extensible, allowing users to benefit from its structure while customizing it to meet their specific needs.

## When to Use This Framework:
Consider a scenario where your data is stored in JSON files, and you want to transfer this data to another format such as CSV, MongoDB, or SQLDB.
Using this framework you can achieve this by creating by implementing a custom reader for JSON and a writer for the desired format, choosing a memoization strategy among those already implemented (or your own) in a way that fits your requirements, and you are ready to proceed.

The framework also supports operations within the same format.


# Commmon use case
The framework comes with implementations for common features, such as:
- AutoSaving: Schedule automatic saves at a fixed rate.
  - This feature is implemented using threads to ensure performance. if you intend to use this functionality, make sure to use synchronized data structures to avoid potential problems.

Additionally, it includes implementations for common data formats like: 
- Json
- MongoDB
...with more formats in development.
