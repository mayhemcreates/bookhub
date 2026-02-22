# BookHub 

A book repository where users can perform basic CRUD actions, as well as search and filter books. Consists of a .net API back-end, and Vue.js front-end. 

---

## Setup

### BookHub.Api

Run the API server -> `dotnet run`

### Bookhub.Web

1. run `npm install`
2. run `npm run dev`

---

## Testing 

Bookhub.Tests -> run `dotnet test`
Vitest (from BookHub.Web) -> run `npm run test:unit`

---

## Notes

- Some responsive sizing is implemented in typescript - a resize could be implemented with more time, but for now requires a refresh on resize.
- Only My Books and individual book views have been implemented at this point.
