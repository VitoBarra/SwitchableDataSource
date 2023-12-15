# Disclaimer
This project is currently in its early stages of development and is not recommended for production use. It requires further refinement and redesign, so proceed at your own risk. Documentation will be provided once the project reaches a satisfactory state.

# Motif of This Framework

The SwitchableDataSource framework aims to simplify the management of data interactions, including reading and writing operations to a data source. It provides a platform where you need to write minimal code to interact with the data source. Additionally, it offers an easy way to compose multiple data sources and manage migrations between them.

This Framework also give you an abstraction on the data, so you can use the object as a "source" of data ignoring how is read and writed

The framework aspires to be highly flexible and extensible, enabling users to leverage its structure while tailoring it to suit their unique requirements.

## When to Use This Framework:
Consider a scenario where your data is stored in JSON files, and you want to transfer this data to another format such as CSV, MongoDB, or SQLDB.
Using this framework you can achieve this by creating by implementing a custom reader for JSON and a writer for the desired format, choose a memoization strategy among those already implemented (or your ouwn) in a way that fits your requirements, and you are ready to proceed.

The framework also supports operations within the same format.


# Commmon use case
The framework comes with implementations for common features, such as:

- AutoSaving: Schedule automatic saves at a fixed rate.
  - This feature is implemented with threads to ensure performance. Exercise caution and use synchronized data structures when employing this feature.

Additionally, it includes implementations for common data formats like:
Json
MongoDB
...with more formats in development.


