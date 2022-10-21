//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;


class MemberCollection : IMemberCollection
{
    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }


    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        // Create new member of class Member
        Member newMember = new Member(member.FirstName, member.LastName, member.ContactNumber, member.Pin);

        // Increment counter
        count++;

        // Initialise vairbales for binary search
        int left = 0;
        int right = Number - 1;
        int pointer = 0;

        // Binary search to find location to insert new member in alphabetical order
        while (left < right && Number > 1)
        {
            // Find middle point of collection
            pointer = (int)(Math.Floor((Decimal)((left + right) / 2)));

            // Compare new member to middle(pointer) member
            int compare = newMember.CompareTo(members[pointer]);

            // Determine if new member is already in the collection
            if (compare == 0)
            {
                // Decrement counter as member was not added
                count--;
            }
            // New member comes after pointer member in dictionary order
            else if (compare == 1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = right;
                }
                left = pointer;
            }
            // New member comes before pointer member in dictionary order
            else if (compare == -1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = left;
                }
                right = pointer;
            }
        }

        // Determine if the collection is not emtpy
        if (!IsEmpty())
        {
            // Move all members to make room for new member
            for (int i = Number - 1; i > pointer; i--)
            {
                members[i] = members[i - 1];
            }
        }
        // Add new member in collection
        members[pointer] = newMember;
    }

    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {
        // Create new member of class Member
        Member deleteMember = new Member(aMember.FirstName, aMember.LastName);

        // Initialise vairbales for binary search
        int left = 0;
        int right = Number - 1;
        int pointer = 0;

        // Binary search to find member to be deleted from collection
        while (left < right && Number > 1)
        {
            // Find middle point of collection
            pointer = (int)(Math.Floor((Decimal)((left + right) / 2)));

            // Compare member to be delted to middle(pointer) member
            int compare = deleteMember.CompareTo(members[pointer]);

            // Determine if member has been found
            if (compare == 0)
            {
                // Found member that needs to be deleted
                break;
            }
            // Member to be delted comes after pointer member in dictionary order
            else if (compare == 1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = right;
                }
                left = pointer;
            }
            else if (compare == -1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = left;
                }
                right = pointer;
            }
        }
        // Determine if delete member is in position of pointer
        if (deleteMember.CompareTo(members[pointer]) == 0)
        {
            // Delete member from collection
            members[pointer] = null;
            // Determine if the collection is not emtpy
            if (!IsEmpty())
            {
                // Move all members to remove space created by deleting member
                for (int i = pointer; i < Number - 1; i++)
                {
                    members[i] = members[i + 1];
                }
            }
            // Decrease count variable
            count--;
        }
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        if (IsEmpty())
        {
            return false;
        }

        // Create new member of class Member
        Member searchMember = new Member(member.FirstName, member.LastName);

        // Initialise variables required for binary search
        int left = 0;
        int right = Number - 1;
        int pointer = 0;

        // Binary search to determine if member is in the collection
        while (left < right && Number > 1)
        {
            // Find middle point of collection
            pointer = (int)(Math.Floor((Decimal)((left + right) / 2)));

            // Compare new member to middle(pointer) member
            int compare = searchMember.CompareTo(members[pointer]);

            // Determine if member is equal to pointer member
            if (compare == 0)
            {
                // Member is in collection return true
                return true;
            }
            // Search member comes after pointer member in dictionary order
            else if (compare == 1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = right;
                }
                left = pointer;
            }
            // Search member comes before pointer member in dictionary order
            else if (compare == -1)
            {
                // Determine if only one member left to compare with in collection
                if (right - left == 1)
                {
                    pointer = left;
                }
                right = pointer;
            }
        }
        // Determine if search member is in position of pointer
        if (searchMember.CompareTo(members[pointer]) == 0)
        {
            // Return true as member has been found
            return true;
        }
        // Search member is not in collection -> return false
        return false;
    }

    // Find a given member in this member collection
    // Pre-condition: nil
    // Post-condition: return the reference of the member object in the member collection, if this member is in the member collection; return null otherwise; member collection remains unchanged
    public IMember Find(IMember member)
    {
        if (count == 0)
            return null;
        // To be implemented by students in Phase 1
        int left = 0, right = Number - 1, mid = left + (right - left) / 2;
        while (left < right)
        {
            mid = left + (right - left) / 2;

            if (member.CompareTo(members[mid]) == 0)
                return members[mid];

            if (member.CompareTo(members[mid]) == 1)
            {
                left = mid + 1;
            }
            else
            {
                right = mid;
            }
        }
        if (member.CompareTo(members[left]) == 0)
            return members[left];
        else
            return null;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }

    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }


}

