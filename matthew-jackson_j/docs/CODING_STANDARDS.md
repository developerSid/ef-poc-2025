# Coding Standards

## Naming
- Function and method names should use UpperCamelCase.

## Usings
- Prefer project-level `GlobalUsings.cs` to centralize common namespaces.
- Keep file-level `using` statements for specialized or rare dependencies.

## Documentation Comments
- Use `/// <inheritdoc />` for overrides and interface implementations.
- Add one-line XML summaries only for public types/methods that are not self-explanatory.
- Avoid param/returns docs unless there's nuance.

## Decision Logging
- Add short, actionable decisions to `docs/README.md` under **Phase 1 Decisions**.
- Include the rationale in a single sentence.
- If the list grows beyond ~6 items, move decisions to `docs/DECISIONS.md` and leave a link in `docs/README.md`.

## Documentation Ownership
- Do not update `docs/STATEMENT_OF_WORK.md`; it is a fixed delivery specification.