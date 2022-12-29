# API Documentation

This document is intended to serve as a more detailed reference of the types and members found in the `EbayScraper` namespace. 

## Enumerations

There are three enumeration types in `ebay-scraper`: [`ListingCondition`](#listingcondition), [`ListingFormat`](#listingformat), and [`ListingVisibility`](#listingvisibility). These enumeration types are mainly intended to clean up and shorten the argument interfaces for methods of the [`Query`](#query) class, although they also find use in the [`Listing`](#listing) class as well.

### `ListingCondition`

Provides an enumeration type used to indicate to the [`Query`](#query) object the state (physical condition) of the items to be filtered for.

Attributes: `[Flags]`

Members:
1. `New`: Item is new or otherwise unused
2. `OpenBox`: The original packaging is opened but the item is otherwise new

### `ListingFormat`

### `ListingVisibility`

## Classes

### `Listing`

### `Query`

### `RunOptions`