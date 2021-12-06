export const data = [
    {
        id: "1",
        first: "Alex",
        last: "Dane",
        isPrimary: true,
        address: "5457 S 700 E, Whitestown, IN 46075",
        enrolledDate: "2021/12/01",
        active: true,
        policyNumber: "123",
        primaryId: "0",
        relation: "primary",
        dependants: [
            {
                id: "2",
                first: "Aardvark",
                last: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                active: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "spouse"
            },
            {
                id: "3",
                first: "Baboon",
                last: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                active: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "child"
            },
            {
                id: "4",
                first: "Cheetah",
                last: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/01",
                active: true,
                policyNumber: "123",
                primaryId: "1",
                relation: "child"
            },
        ],
    },
    {
        id: "5",
        first: "Izuku",
        last: "Midoria",
        isPrimary: true,
        address: "123 Fake Street, Indianapolis, IN 46260",
        enrolledDate: "2021/12/02",
        active: true,
        policyNumber: "123",
        primaryId: "0",
        relation: "primary",
        dependants: [
            {
                id: "6",
                first: "Aardvark",
                last: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/02",
                active: true,
                policyNumber: "123",
                primaryId: "5",
                relation: "spouse"
            },
            {
                id: "7",
                first: "Baboon",
                last: "Dane",
                isPrimary: false,
                address: "5457 S 700 E, Whitestown, IN 46075",
                enrolledDate: "2021/12/02",
                active: true,
                policyNumber: "123",
                primaryId: "5",
                relation: "child"
            },
        ],
    },
];
