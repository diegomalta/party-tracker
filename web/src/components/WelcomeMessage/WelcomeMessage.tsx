import React from "react";

interface WelcomeMessageProps {
    guestName: string
}


const WelcomeMessage = ({ guestName }: WelcomeMessageProps) => {
    return (<div className="text-center text-3xl font-bold pt-6">
        <p>{guestName}, You're invited to Linas's 8th birthday &#127874; party! &#127881;&#127881;&#127881;</p>
    </div>)
}

export default WelcomeMessage;