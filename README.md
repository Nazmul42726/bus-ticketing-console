## Description

This repository contains a clean, compilable C# console application that implements a complete Bus Ticket Booking & Billing System. The codebase models real-world transportation entities—including user accounts, physical bus fleets, routes, interactive seating reservations, and payment processing. The project is strictly structured using object-oriented programming (OOP) principles and follows SOLID design patterns to keep data management, scheduling, and invoicing decoupled and maintainable.

---

## Motive

The central objective of this project is to build a predictable, conflict-free backend system that bridges the gap between digital data and real-world station operations. The technical and structural goals include:

- **Separation of Concerns (SRP):** Moving operational variables like `CoachNumber` and seat maps out of static physical containers (`Bus`) and directly into the timeline (`Schedule`) to support seamless vehicle swapping without breaking ticket histories.
- **Typo-Proof Data Entry:** Replacing loose string text inputs with guided console menu choices (such as specific multi-column options and contextual seat limits based on class selections) to ensure strict database integrity.
- **Algorithmic Validation:** Enforcing backend safety parameters to actively prevent duplicate seating reservations or the allocation of inadequate backup buses.
- **Academic Evaluation:** Demonstrating a practical, runnable grasp of OOP core pillars (Encapsulation, Abstraction, Inheritance, and Polymorphism) alongside decoupled architecture principles for an assignment submission.
