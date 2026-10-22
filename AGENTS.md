<!-- 
  AGENTS.md
  https://gist.github.com/APrettyCoolProgram/09dc9d361d968edcf91520c99a6d5114
  Last updated 261021
-->

# Overview

This AGENTS.md file provides an overview of all agents used in this repository, including their responsibilities and the files they apply to.

Please review all agents listed in the Agent Index to understand which agent is responsible for which files and tasks.

## Agent Index

The Agent Index lists all agents, the files they apply to, and their purposes.

Use the **Applies to** column to find candidate agents for a file, then use the **Purpose** column to select by task.

| Agent                              | Applies to (glob) | Purpose                                      |
|------------------------------------|-------------------|----------------------------------------------|
| `AGENT-CSharp-ProjectFlow.md`      | `**/*.cs`         | Document project structure and runtime flows |
| `AGENT-CSharp-XmlDocumentation.md` | `**/*.cs`         | Add/maintain XML doc comments                |

## Order of Applying Agents

Apply agents in this order:

1. `AGENT-CSharp-XmlDocumentation.md`
2. `AGENT-CSharp-ProjectFlow.md`

If a file does not match any glob in the Agent Index, do not apply any agent-specific instructions; follow default repository conventions and do not modify the file unless explicitly asked.

## CSharp agents

@./.github/agents/AGENT-CSharp-ProjectFlow.md
@./.github/agents/AGENT-CSharp-XmlDocumentation.md

---

*END OF AGENTS.md*
