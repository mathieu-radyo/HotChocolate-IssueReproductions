
# HotChocolate Issue Reproduction

This repository demonstrates an issue when using `[UseConnection]` in combination with `[UseProjection]` in HotChocolate.

---

## 🔁 1. Steps to Reproduce

1. Clone this repository
2. Launch the project (`dotnet run`)
3. Open GraphQL Playground or Studio
4. Run the following query:

```graphql
query {
  countries(first: 5) {
    pageInfo {
      hasNextPage
      hasPreviousPage
      startCursor
      endCursor
      forwardCursors {
        page
        cursor
      }
      backwardCursors {
        page
        cursor
      }
    }
    nodes {
      id
      name
      emoji
      emojiU
      capital
      cities {
        name
        wikiDataId
      }
    }
    edges {
      cursor
    }
    totalCount
  }
}
````

---

## ✅ 2. What is Expected?

The query should return:

* A paginated list of countries using **relative cursors**
* Associated child entities like `cities`
* Proper filtering, sorting, and projection applied
* No overfetching in the database (thanks to projection)

---

## ❌ 3. What is Actually Happening?

* With `[UseProjection]` + `[UseConnection]`, the application fails with:

  ```
  System.ArgumentException: Type 'HotChocolate.Types.Pagination.PageConnection`1[...]' does not have a default constructor (Parameter 'type')
  ```

* Without `[UseProjection]`, the query works — but **child entities like `cities` are not fetched**, and full objects are retrieved from the database (overfetching).

---

## 🙋‍♀️ Questions

* Is this a limitation by design?
* Is support for `UseProjection` with `PageConnection<T>` planned?
* Are there workarounds to get both relative cursors and projection?

```
