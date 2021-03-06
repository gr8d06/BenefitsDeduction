export const data = [
    {
        id: "1",
        firstName: "Alex",
        lastName: "Dane",
        isPrimary: true,
        address: "5457 S 700 E, Whitestown, IN 46075",
        enrolledDate: "2021/12/01",
        isActive: true,
        policyNumber: "123",
        primaryId: "0",
        relation: "primary",
        dependants: [
            {
                id: "2",
                firstName: "Aardvark",
                lastName: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                isActive: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "spouse"
            },
            {
                id: "3",
                firstName: "Baboon",
                lastName: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                isActive: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "child"
            },
            {
                id: "4",
                firstName: "Cheetah",
                lastName: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                isActive: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "child"
            },
        ],
    },
    {
        id: "5",
        firstName: "Izuku",
        lastName: "Midoria",
        isPrimary: true,
        address: "123 Fake Street, Indianapolis, IN 46260",
        enrolledDate: "2021/12/02",
        isActive: true,
        policyNumber: "123",
        primaryId: "0",
        relation: "primary",
        dependants: [
            {
                id: "6",
                firstName: "Aardvark",
                lastName: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/02",
                isActive: true,
                policyNumber: "123",
                primaryId: "5",
                relation: "spouse"
            },
            {
                id: "7",
                firstName: "Baboon",
                lastName: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/02",
                isActive: true,
                policyNumber: "123",
                primaryId: "5",
                relation: "child"
            },
        ],
    },
];
